using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void Start()
    {
        
    }

    private void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 50f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();

            player.spawn = transform.position + Vector3.up*1.5f;

            Destroy(gameObject);
        }
    }
}
