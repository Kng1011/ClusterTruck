using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{

    public Transform[] wheels; // Lista de transformações das rodas
    public float rotationSpeed = 100f; // Velocidade de rotação das rodas

    private Rigidbody rb; // Rigidbody do caminhão

    void Start()
    {
        // Obtém o componente Rigidbody do caminhão
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calcula a velocidade do caminhão baseada na sua velocidade linear
        float truckSpeed = rb.velocity.magnitude;

        // Calcula a direção do movimento do caminhão
        Vector3 truckDirection = rb.velocity.normalized;

        // Calcula a rotação das rodas baseada na velocidade do caminhão
        float rotationAmount = rotationSpeed * truckSpeed * Time.deltaTime;

        // Aplica a rotação nas rodas
        foreach (Transform wheel in wheels)
        {
            // Verifica se a rotação das rodas deve ser no sentido horário ou anti-horário
            float rotationDirection = Vector3.Dot(wheel.forward, truckDirection) > 0 ? 1f : -1f;

            // Rotação das rodas
            wheel.Rotate(Vector3.right, rotationAmount * rotationDirection);
        }
    }
}
