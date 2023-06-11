using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera1;
    Vector3 forward;
    Vector3 right;
    
    [HideInInspector]
    public Vector3 spawn;

    private Rigidbody _rigidBody;
    
    public float limitV;
    public float speed;
    
    [Range(0.0f, 1.0f)]
    public float brake;
    public float height;
    public float gravity;
    
    [HideInInspector]
    public bool canJump;
    
    [HideInInspector]
    public bool canPlay;


    private bool wonGame;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        spawn = transform.position;
        canJump = true;
        canPlay = true;
        limitV = 30;
        height = 8;
        wonGame = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canPlay && !wonGame){
            float horizontalValue = Input.GetAxisRaw("Horizontal");
            float verticalValue = Input.GetAxisRaw("Vertical");
    
            forward = new Vector3(camera1.transform.forward.x, 0.0f, camera1.transform.forward.z).normalized;
            right = new Vector3(camera1.transform.right.x, 0.0f, camera1.transform.right.z).normalized;

            
            if (_rigidBody.velocity.magnitude >= limitV)
            {
                _rigidBody.velocity = _rigidBody.velocity.normalized * limitV;
            }
            else
            {
                _rigidBody.AddForce(forward * speed * verticalValue);
                _rigidBody.AddForce(right * speed * horizontalValue);
            }

            if(Input.GetButton("Jump") && canJump){
                _rigidBody.AddForce(Vector3.up * height, ForceMode.Impulse);
                canJump = false;
            }
            else {
                _rigidBody.AddForce(Vector3.down * gravity);
            }
            //se carregou no alt, reduz a sua velocidade por metade
            if(Input.GetButton("Fire2")){
                _rigidBody.velocity = new Vector3(
                    _rigidBody.velocity.x * brake,
                    _rigidBody.velocity.y,
                    _rigidBody.velocity.z * brake
                );
            }
        }

        else if(wonGame){
            _rigidBody.velocity = new Vector3(
                    _rigidBody.velocity.x * 0.99f,
                    _rigidBody.velocity.y + 0.2f,
                    _rigidBody.velocity.z * 0.99f
                );
        }
        

    }

    void Update(){
        if(canPlay && transform.position.y < -60) {
            canPlay = false;
            Kill();
        }
    }

    private void OnCollisionEnter(Collision other) {
        canJump = true;
    }

    public void Kill(){
        Camera cam = camera1.gameObject.GetComponent<Camera>();
        cam.canMove = false;
        canPlay = false;
        StartCoroutine(Respawn(1.5f, cam));
    }
    IEnumerator Respawn(float delay, Camera camera2)
    {
        yield return new WaitForSeconds(delay);
        transform.position = spawn;
        _rigidBody.velocity = new Vector3();
        _rigidBody.angularVelocity = new Vector3();
        Camera cam = camera2.gameObject.GetComponent<Camera>();
        cam.canMove = true;
        canPlay = true;
    }

    public void WinCutscene(){
        Camera cam = camera1.gameObject.GetComponent<Camera>();
        cam.canMove = true;
        canPlay = false;
        wonGame = true;
    }

    public Vector3 getVelocity()
    {
        return _rigidBody.velocity;
    }
}
