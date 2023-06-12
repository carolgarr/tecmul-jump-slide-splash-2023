using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideWater : MonoBehaviour
{
    public float speed;
    GameObject splash;
    GameObject splashObj;

    void Start(){
        splash =  GameObject.Find("Particle System");
    }

    private void OnCollisionEnter(Collision other){
        if (other.collider.name == "Player")
        {

            Rigidbody player = other.gameObject.GetComponent<Rigidbody>();
            
            Vector3 splashPosition = player.transform.position + new Vector3(0f, -0.5f, 0f);
            splashObj = Instantiate(splash, splashPosition, Quaternion.identity);
            
        }
    }


    private void OnCollisionStay(Collision other)
    {
        if (other.collider.name == "Player")
        {

            Rigidbody player = other.gameObject.GetComponent<Rigidbody>();
            //player.AddForce(-transform.right *speed);
            
            Vector3 splashPosition = player.transform.position + new Vector3(0f, -0.5f, 0f);
            splashObj.transform.position = splashPosition;
            
        }
    }

    
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {

            
            Destroy(splashObj, 1.0f);
        }
    }
}
