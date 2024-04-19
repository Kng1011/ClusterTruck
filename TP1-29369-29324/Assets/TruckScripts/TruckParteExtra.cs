using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckParteExtra : MonoBehaviour
{
    public Portal2 Portal;

    public float MovementSpeed;
    bool canMove = false;
    float startDelay = 2.0f;

    private Rigidbody truckRigidbody;

    void Start()
    {
        truckRigidbody = GetComponent<Rigidbody>();
        this.transform.GetChild(0).GetComponent<Rigidbody>().drag = UnityEngine.Random.Range(0.1f, 1f);
    }


    void Update()
    {
        canMove = Portal.GetCanMove();
      
        if (canMove)
        {
            transform.position += this.transform.forward * Time.deltaTime * MovementSpeed;
        }

    }
}
