using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    public GameObject win;
    public GameObject ingame;
    public GameObject panel;
    public GameObject crosshair;
    public GameObject retryUI;
    public GameObject lose;


    public void RetryGame()
    {

        win.SetActive(false);
        panel.SetActive(false);
        ingame.SetActive(true);
        crosshair.SetActive(true);
        retryUI.SetActive(false);
        lose.SetActive(false);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        SceneManager.LoadScene(1);
    }
}
