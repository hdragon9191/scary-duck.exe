using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEventLockerExit : MonoBehaviour {
    [SerializeField] GameObject door;
    [SerializeField] GameObject tooltipText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip closeLockerClip;
    bool triggerOneTime;

    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Player" && !triggerOneTime) {
            triggerOneTime = true;
            StartCoroutine(OpenDoor(other.gameObject));
        }
    }

    IEnumerator OpenDoor(GameObject player) {
        door.transform.Rotate(0, 0, 90f);
        audioSource.PlayOneShot(closeLockerClip);
        yield return new WaitForSeconds(2.4f);
        door.transform.Rotate(0, 0, -90f);
        triggerOneTime = false;
    }


    private void OnTriggerEnter(Collider other) {
        tooltipText.SetActive(true);
        tooltipText.GetComponent<TextMeshProUGUI>().text = "Repeatedly pressing E to exit";
    }
    private void OnTriggerExit(Collider other) {
        tooltipText.SetActive(false);
    }

}
