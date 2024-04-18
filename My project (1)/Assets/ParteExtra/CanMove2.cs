using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMove2 : MonoBehaviour
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
