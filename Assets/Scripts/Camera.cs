using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start() {
        //Distance from player to camera
        offset = new Vector3(0f, 7f, -7f);
    }

    //Update is called once per frame.
    void Update()
    {
        //Follow player's position
        transform.position = player.position + offset;

        //a camara olha para um ponto imaginario diretamente acima do jogador
        transform.LookAt(player.position + Vector3.up*2);
    }
}
