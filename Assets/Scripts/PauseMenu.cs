using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing = false;
    void Start() {
        menu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(Time.timeScale == 1) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
        if (isShowing) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                SceneManager.LoadScene("Scene_Start");
            }
        }
    }
    public void Resume() {
        Time.timeScale = 1;
        isShowing = false;
        menu.SetActive(isShowing);
    }
}
