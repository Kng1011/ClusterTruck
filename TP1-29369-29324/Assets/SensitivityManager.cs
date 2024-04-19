using UnityEngine;
using UnityEngine.SceneManagement;

public class SensitivityManager : MonoBehaviour
{
    private static SensitivityManager instance;
    public float sensitivityValue = 5f; // Valor padrão

    public static SensitivityManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SensitivityManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("SensitivityManager");
                    instance = obj.AddComponent<SensitivityManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


