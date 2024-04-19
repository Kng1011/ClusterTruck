using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public GameObject player;
    public GameObject posicao;
    
    public bool canMove = false;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            player.transform.position = posicao.transform.position;
            canMove = true;
        }
    }
    public bool GetCanMove() { return canMove; }
}
