using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{
    public new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float cameraY = camera.position.y;

        if(cameraY < 0){
            cameraY = 0;
        }

        transform.position = new Vector3(
            camera.position.x, 
            cameraY * 1f, 
            camera.position.z
        );
    }
}
