using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventLockerExit : MonoBehaviour
{
  [SerializeField]  GameObject door;
    bool triggerOneTime;
    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && !triggerOneTime) {
            triggerOneTime = true;
            StartCoroutine(OpenDoor(other.gameObject));
        }
    }

    IEnumerator OpenDoor(GameObject player) {
        door.transform.Rotate(0,0,90f);
        yield return new WaitForSeconds(2.4f);
        door.transform.Rotate(0, 0, -90f);
        triggerOneTime = false;
    }

}
