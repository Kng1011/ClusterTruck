using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TruckMovement2 : MonoBehaviour
{
    public float MovementSpeed;
    bool canMove = false;
    bool canMove2 = false;
    bool canMove3 = false;
    float startDelay = 2.0f;
    public Portal Portal;
    public Portal Portal2;
    public Portal Portal3;



    private Rigidbody truckRigidbody;

    void Start()
    {
        truckRigidbody = GetComponent<Rigidbody>();
        this.transform.GetChild(0).GetComponent<Rigidbody>().drag = UnityEngine.Random.Range(0.1f, 1f);
    }


    void Update()
    {
        canMove = Portal.GetCanMove();
        canMove2 = Portal2.GetCanMove();
        canMove3 = Portal3.GetCanMove();

        if (canMove || canMove2 || canMove3)
        {
            transform.position += this.transform.forward * Time.deltaTime * MovementSpeed;
        }

    }

}
