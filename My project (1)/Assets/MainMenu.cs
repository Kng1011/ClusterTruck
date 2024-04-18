using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField sensInput;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
     
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeSens(){

        SensitivityManager.Instance.sensitivityValue = float.Parse(sensInput.text);

        Debug.Log(SensitivityManager.Instance.sensitivityValue);
    }

    
}
