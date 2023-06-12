using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameObject gController;

    private void Start() {
        //Get Game Controller
        gController = GameObject.Find("GameController");
    }

    private void Update() {
        transform.Rotate(Vector3.up * Time.deltaTime * 150f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            gController.transform.GetComponent<GameController>().WinGame();
        }
    }
}
