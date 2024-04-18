using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Finish : MonoBehaviour
{

  
    public Timer time;

   
    [SerializeField] TextMeshProUGUI timeValue2;

    public GameObject win;
    public GameObject ingame;
    public GameObject crosshair;
    public GameObject retryUI;
    

    public GameObject panel;
    float elapsedTime;
    bool one = true;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && one)
        {
            one = false;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;

            elapsedTime = time.getTimeValue();
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timeValue2.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            
            panel.SetActive(true);
            retryUI.SetActive(true);
            win.SetActive(true);
            ingame.SetActive(false);
            crosshair.SetActive(false);
            
        }
    }
}
