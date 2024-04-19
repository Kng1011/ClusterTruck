using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public Vector3 posicao;
    public bool canMove = false;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            player.transform.position = posicao;
            canMove = true;
        }
    }

    public bool GetCanMove() { return canMove; }
}
