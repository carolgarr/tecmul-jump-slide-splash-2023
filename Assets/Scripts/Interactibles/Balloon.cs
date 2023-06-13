using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float boost = 12;

    public Material ativo;
    public Material desativado;

    private AudioSource source;

    void Start() { 
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 30f, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            source.Play();
            GetComponent<Collider>().enabled = false;
            Rigidbody player = other.gameObject.GetComponent<Rigidbody>();
            player.AddForce(Vector3.up * boost * 50);

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.GetComponent<MeshRenderer>().material = desativado;
            }

            StartCoroutine(Respawn(3f));
        }
    }

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Collider>().enabled = true;
        for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.GetComponent<MeshRenderer>().material = ativo;
            }
    }
}
