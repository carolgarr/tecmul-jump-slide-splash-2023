using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameObject gController;

    private AudioSource source;

    private void Start() {
        //Get Game Controller
        gController = GameObject.Find("GameController");
        source = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 150f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            source.Play();
            gController.transform.GetComponent<GameController>().WinGame();
        }
    }
}
