using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float height;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name == "Player")
        {
            Rigidbody player = other.gameObject.GetComponent<Rigidbody>();
            player.AddForce(transform.up * height*50, ForceMode.Acceleration);
        }
    }
}
