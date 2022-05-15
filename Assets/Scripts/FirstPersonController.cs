using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif


	public class FirstPersonController : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 4.0f;
		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 6.0f;
		[Tooltip("Crouch speed of the character in m/s")]
		public float CrouchSpeed = 2.0f;
		[Tooltip("Rotation speed of the character")]
		public float mouseSensitifity = 1.0f;
		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;
		[Tooltip("Can bob(move head up and down while moving)")]
		public bool canBob;
		[Tooltip("head Bob speed")]
		public float CrouchHeadBobSpeed = 5.0f;
		public float walkHeadBobSpeed = 5.0f;
		public float SprintHeadBobSpeed = 18.0f;		
		public float CrouchHeadBobAmmount = 5.0f;
		public float WalkHeadBobAmount = 5.0f;
		public float SprintHeadBobAmount = 8.0f;
		private float DefaultYPositionOfCamera;
		public float Timer;

		[Space(10)]
		[Tooltip("The height the player can jump")]
		public float JumpHeight = 1.2f;
		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity = -15.0f;

		[Space(10)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		public float JumpTimeout = 0.1f;
		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;
		[Tooltip("Useful for rough ground")]
		public float GroundedOffset = -0.14f;
		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.5f;
		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90.0f;
		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90.0f;

		// cinemachine
		private float _cinemachineTargetPitch;

		// player
		public float _speed;
		public float targetSpeed;
		private float _rotationVelocity;
		private float _verticalVelocity;
		private float _terminalVelocity = 53.0f;

		// timeout deltatime
		private float _jumpTimeoutDelta;
		private float _fallTimeoutDelta;

		private CharacterController _controller;
		private GameObject _mainCamera;

		private const float _threshold = 0.01f;
	
		public Vector3 inputDirection;
		public Transform CameraRootOfCameraRoot;
		public int fpsLimit = 300;
		public float decreaseSpeed;
		private void Awake()
		{
			// get a reference to our main camera
			if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
			DefaultYPositionOfCamera = CameraRootOfCameraRoot.transform.localPosition.y;
		}

		private void Start()
		{
			_controller = GetComponent<CharacterController>();

			// reset our timeouts on start
			_jumpTimeoutDelta = JumpTimeout;
			_fallTimeoutDelta = FallTimeout;
		}

		private void Update()
		{
			if (Time.timeScale == 1)
			{
            Cursor.lockState = CursorLockMode.Locked;
			}
			else if (Time.timeScale == 0)
			{
            Cursor.lockState = CursorLockMode.None;
			}
            Application.targetFrameRate = fpsLimit;
			JumpAndGravity();
			GroundedCheck();
			Move();
			if(canBob)
			{
				HeadBob();
			}
			if (Input.GetButton("crouch"))
			{
				CameraRootOfCameraRoot.localPosition = new Vector3(CameraRootOfCameraRoot.localPosition.x, 0.9f, CameraRootOfCameraRoot.localPosition.z);
			}
			else
			{
				CameraRootOfCameraRoot.localPosition = new Vector3(CameraRootOfCameraRoot.localPosition.x, 1.1f, CameraRootOfCameraRoot.localPosition.z);
			}
			CameraRotation();
		}

		private void HeadBob()
		{
			if (!Grounded) return;
			if (Mathf.Abs(inputDirection.x) > 0.1f || Mathf.Abs(inputDirection.z) > 0.1f )
			{
				Timer += Time.deltaTime * (Input.GetButton("_Shift") ? SprintHeadBobSpeed : Input.GetButton("crouch") ? CrouchHeadBobSpeed: walkHeadBobSpeed);
				CinemachineCameraTarget.transform.localPosition = new Vector3(CinemachineCameraTarget.transform.localPosition.x, DefaultYPositionOfCamera = Mathf.Sin(Timer) * (Input.GetButton("_Shift") ? SprintHeadBobAmount : Input.GetButton("crouch") ? CrouchHeadBobAmmount : WalkHeadBobAmount), CinemachineCameraTarget.transform.localPosition.z);
			}
		}

		private void GroundedCheck()
		{
			// set sphere position, with offset
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
			Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void CameraRotation()
		{
			{
				//Don't multiply mouse input by Time.deltaTime
				float deltaTimeMultiplier =  1 *Time.deltaTime;
				
				float xPos = Input.GetAxis("Mouse X") * mouseSensitifity * Time.deltaTime;
				float yPos = Input.GetAxis("Mouse Y") * mouseSensitifity * Time.deltaTime;
				// clamp our pitch rotation
				_cinemachineTargetPitch -= yPos;
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

				// Update Cinemachine camera target pitch
				CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

				// rotate the player left and right
				transform.Rotate(Vector3.up * xPos);
			}
		}

		private void Move()
		{
			// set target speed based on move speed, sprint speed and if sprint is pressed
			targetSpeed = Input.GetButton("_Shift") ? SprintSpeed : Input.GetButton("crouch") ? CrouchSpeed : MoveSpeed;
			// a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

			// note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is no input, set the target speed to 0
			if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) targetSpeed = 0.0f;

			// a reference to the players current horizontal velocity
			float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;
			Debug.Log("current horizontal speed" + currentHorizontalSpeed);
			float speedOffset = 0.1f;
			// float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

			// accelerate or decelerate to target speed
			// if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
			// {
			// 	// creates curved result rather than a linear one giving a more organic speed change
			// 	// note T in Lerp is clamped, so we don't need to clamp our speed
			// 	// _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

			// 	// round speed to 3 decimal places
			// 	_speed = Mathf.Round(_speed * 1000f) / 1000f;
			// }
			// else
			// {
				_speed = targetSpeed - decreaseSpeed;
			// }

			// normalise input direction
			inputDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

			// note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
			// if there is a move input rotate player when the player is moving
			// if (_input.move != Vector2.zero)
			// {
			// 	// move
			// 	inputDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
			// }

			// move the player
			_controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
		}

		private void JumpAndGravity()
		{
			if (Grounded)
			{
				// reset the fall timeout timer
				_fallTimeoutDelta = FallTimeout;

				// stop our velocity dropping infinitely when grounded
				if (_verticalVelocity < 0.0f)
				{
					_verticalVelocity = -2f;
				}

				// Jump
				if (Input.GetButton("Jump") && _jumpTimeoutDelta <= 0.0f)
				{
					// the square root of H * -2 * G = how much velocity needed to reach desired height
					_verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
				}

				// jump timeout
				if (_jumpTimeoutDelta >= 0.0f)
				{
					_jumpTimeoutDelta -= Time.deltaTime;
				}
			}
			else
			{
				// reset the jump timeout timer
				_jumpTimeoutDelta = JumpTimeout;

				// fall timeout
				if (_fallTimeoutDelta >= 0.0f)
				{
					_fallTimeoutDelta -= Time.deltaTime;
				}

				// if we are not grounded, do not jump
				// _input.jump = false;
			}

			// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
			if (_verticalVelocity < _terminalVelocity)
			{
				_verticalVelocity += Gravity * Time.deltaTime;
			}
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		private void OnDrawGizmosSelected()
		{
			Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
			Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

			if (Grounded) Gizmos.color = transparentGreen;
			else Gizmos.color = transparentRed;

			// when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
			Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
		}
	}