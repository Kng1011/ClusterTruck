using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Death : MonoBehaviour
{
    public GameObject lose;
    public GameObject ingame;
    public GameObject crosshair;
    public GameObject retryUI;
    public GameObject panel;

    float elapsedTime;
    
    [SerializeField] TextMeshProUGUI timeValue2;
    
    public Timer time;
    bool one = true;
    bool isFinished = false;

    public AudioSource src;
    public AudioClip death;

    public void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Floor" && one && !isFinished) {

            one = false;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;

            elapsedTime = time.getTimeValue();
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timeValue2.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            src.clip = death;
            src.Play();

            lose.SetActive(true);
            panel.SetActive(true);
            ingame.SetActive(false);
            crosshair.SetActive(false);
            retryUI.SetActive(true);
          
        }

        if (other.gameObject.tag == "Logs" && one && !isFinished)
        {
            one = false;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;

            elapsedTime = time.getTimeValue();
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timeValue2.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            src.clip = death;
            src.Play();

            lose.SetActive(true);
            panel.SetActive(true);
            ingame.SetActive(false);
            crosshair.SetActive(false);
            retryUI.SetActive(true);
    
        }

        if (other.gameObject.tag == "Finish" && one)
        {
            isFinished = true;
        }

    }
}
