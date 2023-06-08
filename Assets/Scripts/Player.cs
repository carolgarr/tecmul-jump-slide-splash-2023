using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Walk
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        float verticalValue = Input.GetAxisRaw("Vertical");

        
        _rigidBody.AddForce(Vector3.forward * speed * verticalValue);
        _rigidBody.AddForce(Vector3.right * speed * horizontalValue);

        if(Input.GetButton("Jump") && canJump){
            _rigidBody.AddForce(Vector3.up * height, ForceMode.Impulse);
            canJump = false;
        }
        else {
            _rigidBody.AddForce(Vector3.down * gravity);
        }
    }

    //Jump
    private void OnCollisionEnter(Collision other) {
        canJump = true;
    }
}
