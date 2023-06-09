using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Transform camera;
    Vector3 forward;
    Vector3 right;
    public Vector3 spawn;

    //Walk
    public float speed;
    private Rigidbody _rigidBody;
    //Jump
    public float height;
    public float gravity;
    private bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Walk
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        float verticalValue = Input.GetAxisRaw("Vertical");

        Vector3 forward = new Vector3(camera.transform.forward.x, 0.0f, camera.transform.forward.z).normalized;
        Vector3 right = new Vector3(camera.transform.right.x, 0.0f, camera.transform.right.z).normalized;
        
        _rigidBody.AddForce(forward * speed * verticalValue);
        _rigidBody.AddForce(right * speed * horizontalValue);

        if(Input.GetButton("Jump") && canJump){
            _rigidBody.AddForce(Vector3.up * height, ForceMode.Impulse);
            canJump = false;
        }
        else {
            _rigidBody.AddForce(Vector3.down * gravity);
        }

        
    }

    void Update(){
        if(transform.position.y < -5) {
            Respawn();
        }
    }

    //Jump
    private void OnCollisionEnter(Collision other) {
        canJump = true;
    }

    private void Respawn(){
        transform.position = spawn;
        _rigidBody.velocity = new Vector3(0,0,0);
    }
}
