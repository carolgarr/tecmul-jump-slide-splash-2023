using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    GameObject splash;
    GameObject splashObj;
    void Start()
    {
         splash =  GameObject.Find("Particle System");
    }


    private void OnCollisionEnter(Collision other){
        if (other.collider.name == "Player"){
        Vector3 splashPosition = other.transform.position + new Vector3(0f, -0.5f, 0f);
        splashObj = Instantiate(splash, splashPosition, Quaternion.identity);
        }
    }
     private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            Vector3 splashPosition = collision.transform.position + new Vector3(0f, -0.5f, 0f);
            splashObj.transform.position = splashPosition;
            
        }
    }
     private void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {
           Destroy(splashObj, 0.1f);
        }
    }
}
