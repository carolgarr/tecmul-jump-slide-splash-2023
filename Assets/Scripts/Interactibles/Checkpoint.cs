using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material desativado;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 50f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            source.Play();

            GetComponent<Collider>().enabled = false;
            Player player = other.gameObject.GetComponent<Player>();

            player.spawn = transform.position + Vector3.up;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.GetComponent<MeshRenderer>().material = desativado;
            }
        }
    }
}
