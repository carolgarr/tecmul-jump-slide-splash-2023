using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject gController;

    private void Start() {
        //Get Game Controller
        gController = GameObject.Find("GameController");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player")
        {
            //Delete Collectible
            Destroy(gameObject);
            //Update stored number of Collectibles
            gController.transform.GetComponent<GameController>().numberCollectibles -= 1;
        }
    }
}
