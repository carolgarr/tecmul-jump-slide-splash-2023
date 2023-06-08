using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start() {
        //Distance from player to camera
        offset = new Vector3(0.0f, 5.0f, -5f);
    }

    //Update is called once per frame.
    void Update()
    {
        //Follow player's position
        transform.position = player.position + offset;
    }
}
