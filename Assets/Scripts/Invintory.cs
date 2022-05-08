using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory : MonoBehaviour
{
    public int NumberOfItemInInevintory;
    public List<GameObject> DucksInInvintory;
    public LayerMask layerMask;
    public float Reach = 10;
    public Transform TeleportItemHere, duckSpawner;
    public GameObject DucksInInvintory_;
    public FirstPersonController FirstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (NumberOfItemInInevintory >= 1) FirstPersonController.decreaseSpeed = 1.2f;
      if (NumberOfItemInInevintory >= 3) FirstPersonController.decreaseSpeed = 3f;
      if (NumberOfItemInInevintory >= 3) 
      {
      FirstPersonController.decreaseSpeed = 3.5f; 
      return;
      } 
     if (Input.GetButtonDown("Fire1"))
     {
         // Cast a ray from the camera to where you clicked
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
         if (Physics.Raycast(ray, out RaycastHit hit,Reach, layerMask))
         {
            NumberOfItemInInevintory ++;
            GameObject hitObject = hit.collider.gameObject;
            // Add hitObject to inventory...
            DucksInInvintory.Add(hitObject);
          }
        foreach (GameObject item in DucksInInvintory)
        {
            item.transform.position = new Vector3 (0, -50, 0);
            item.transform.parent = this.transform;
        }
      }
    }
    void LateUpdate()
    {
     if (Input.GetButtonDown("Fire2"))
     {
        if (DucksInInvintory.Count <= 0) return;
        NumberOfItemInInevintory --;
        int number = DucksInInvintory.Count;
        DucksInInvintory_ = DucksInInvintory[number -1];
        DucksInInvintory.Remove(DucksInInvintory_);
        DucksInInvintory_.transform.localPosition = new Vector3(TeleportItemHere.transform.localPosition.x, TeleportItemHere.transform.localPosition.y + 1, TeleportItemHere.transform.localPosition.z);
        DucksInInvintory_.transform.parent = duckSpawner;   
        }
    }
}
