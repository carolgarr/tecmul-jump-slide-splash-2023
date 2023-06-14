using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    public float speed1;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Player")
        {

            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            player.AddForce(player.velocity *speed1);
        }
    }
}
