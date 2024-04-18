using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{

    public Transform[] wheels; // Lista de transforma��es das rodas
    public float rotationSpeed = 100f; // Velocidade de rota��o das rodas

    private Rigidbody rb; // Rigidbody do caminh�o

    void Start()
    {
        // Obt�m o componente Rigidbody do caminh�o
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calcula a velocidade do caminh�o baseada na sua velocidade linear
        float truckSpeed = rb.velocity.magnitude;

        // Calcula a dire��o do movimento do caminh�o
        Vector3 truckDirection = rb.velocity.normalized;

        // Calcula a rota��o das rodas baseada na velocidade do caminh�o
        float rotationAmount = rotationSpeed * truckSpeed * Time.deltaTime;

        // Aplica a rota��o nas rodas
        foreach (Transform wheel in wheels)
        {
            // Verifica se a rota��o das rodas deve ser no sentido hor�rio ou anti-hor�rio
            float rotationDirection = Vector3.Dot(wheel.forward, truckDirection) > 0 ? 1f : -1f;

            // Rota��o das rodas
            wheel.Rotate(Vector3.right, rotationAmount * rotationDirection);
        }
    }
}
