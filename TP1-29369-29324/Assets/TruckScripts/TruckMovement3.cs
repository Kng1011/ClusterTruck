using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TruckMovement3 : MonoBehaviour
{
    public float MovementSpeed;
    bool canMove = false;
    float startDelay = 13.0f;


    void Start()
    {
        this.transform.GetChild(0).GetComponent<Rigidbody>().drag = UnityEngine.Random.Range(0.1f, 1f);
        Invoke("StartMoving", startDelay);
    }


    void Update()
    {
        if (canMove)
        {
            transform.position += this.transform.forward * Time.deltaTime * MovementSpeed;
        }

    }

    private void StartMoving()
    {
        canMove = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
