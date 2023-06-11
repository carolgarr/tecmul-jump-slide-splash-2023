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
        transform.position = new Vector3(camera.position.x, 0, camera.position.z);
    }
}
