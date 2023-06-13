using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideWater : MonoBehaviour
{
    public float speed;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Player")
        {

            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            player.AddForce(-transform.right *speed);
        }
    }
}
