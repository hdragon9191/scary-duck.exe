using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenu_;
    public bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("PauseMenu"))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        gamePaused = false;
        PauseMenu_.SetActive(false);
        Time.timeScale = 1;
    }
    void Pause()
    {
        gamePaused = true;
        PauseMenu_.SetActive(true);
        Time.timeScale = 0;
    }
    public void GoToMainMenu()
    {
        Debug.Log("amine");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
