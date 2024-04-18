using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;
    public Transform orientation;

    private bool isMoving = false;
    private bool initialMovementDone = false; // Adicionando uma flag para controlar o movimento inicial
    private float xRotation = 0f;
    private float yRotation = 0f;

    private bool isGameSceneLoaded = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Inicializa a rotação da câmera e orientação
        transform.rotation = Quaternion.Euler(Vector3.zero);
        orientation.rotation = Quaternion.Euler(Vector3.zero);

        LoadMouseSensitivity();
    }

    private void Update()
    {
        // Obtém a entrada do mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Verifica se o jogador está se movendo
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Verifica se o movimento inicial já foi realizado
        if (!initialMovementDone)
        {
            // Se o jogador estiver se movendo, marca que o movimento inicial foi feito
            if (isMoving)
            {
                initialMovementDone = true;
            }
            else
            {
                // Não atualize a rotação da câmera se o movimento inicial ainda não foi feito
                return;
            }
        }

        // Atualiza a rotação apenas se o jogador estiver em movimento
        if (isMoving || initialMovementDone)
        {
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            // Rotaciona a câmera e a orientação
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    private void LoadMouseSensitivity()
    {
        // Verifica se há uma sensibilidade de mouse salva, se não, usa a sensibilidade padrão
        if (isGameSceneLoaded)
        {
            Debug.Log(SensitivityManager.Instance.sensitivityValue);
           sensX = SensitivityManager.Instance.sensitivityValue;
           sensY = SensitivityManager.Instance.sensitivityValue;
        }
    }

    
  

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se a cena carregada é a cena de jogo (ou qualquer outra cena que você está interessado)
        if (scene.buildIndex == 1)
        {
            // Faça algo específico para essa cena
            isGameSceneLoaded = true;
            Debug.Log("A cena " + scene.name + " foi carregada.");
        }
    }

}

