using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEventLockerHide : MonoBehaviour {
    GameObject playerTrigger;
    bool isLockedPosition;
    bool triggerOneTime;
    [SerializeField] Transform lockerPoint;
    [SerializeField] GameObject tooltipText;
    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.F) && other.tag == "Player" && !triggerOneTime) {
            triggerOneTime = true;
            gameObject.transform.GetChild(1).gameObject.layer = LayerMask.NameToLayer("Locker");
            StartCoroutine(OpenAndCloseDoorAnimation(other.gameObject));
        }

    }

    IEnumerator OpenAndCloseDoorAnimation(GameObject player) {
        isLockedPosition = true;
        player.GetComponent<CharacterController>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
        playerTrigger = player;
        yield return new WaitForSeconds(2.4f);
        gameObject.transform.GetChild(1).gameObject.layer = LayerMask.NameToLayer("Default");
        gameObject.transform.GetChild(1).GetComponent<Animator>().Rebind();
        gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = false;
        isLockedPosition = false;
        triggerOneTime = false;
        player.GetComponent<CharacterController>().enabled = true;

    }

    void LockPlayerPosition() {
        playerTrigger.transform.position = Vector3.Lerp(playerTrigger.transform.position, gameObject.transform.position, Time.deltaTime * 1);
        playerTrigger.transform.rotation = Quaternion.Lerp(playerTrigger.transform.rotation, gameObject.transform.rotation, Time.deltaTime * 1);
    }

    private void Update() {
        if (isLockedPosition)
            LockPlayerPosition();
    }


    private void OnTriggerEnter(Collider other) {
        tooltipText.SetActive(true);
        tooltipText.GetComponent<TextMeshProUGUI>().text = "Press F to hide";
    }
    private void OnTriggerExit(Collider other) {
        tooltipText.SetActive(false);
    }
  
}
