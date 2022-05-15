using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    bool menuOnOff;

    void Start() {
        menuOnOff = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menuOnOff = !menuOnOff;
            if (menuOnOff) {
                transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
