using UnityEngine;

public class Random : MonoBehaviour
{
    public Transform[] objetos = new Transform[3];

    public void Start()
    {
        TrocarObjetos();
    }

    public void TrocarObjetos()
    {
        // Embaralhar a ordem dos objetos no array
        for (int i = 0; i < objetos.Length; i++)
        {
            Transform temp = objetos[i];
            int randomIndex = UnityEngine.Random.Range(0, objetos.Length);
            objetos[i] = objetos[randomIndex];
            objetos[randomIndex] = temp;
        }
        
        // Definir novas posições relativas aos objetos trocados
        for (int i = 0; i < objetos.Length - 1; i++)
        {
            Vector3 posicaoTemp = objetos[i].position;
            objetos[i].position = objetos[i + 1].position;
            objetos[i + 1].position = posicaoTemp;
        }
    }

}
