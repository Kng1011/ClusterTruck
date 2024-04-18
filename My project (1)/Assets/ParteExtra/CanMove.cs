using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMove : MonoBehaviour
{
    bool canMove = false;
    private void OnTriggerEnter(Collider other)
    {
        canMove = true;
    }

    public bool getCanMove()
    {
        return canMove;
    }

}
