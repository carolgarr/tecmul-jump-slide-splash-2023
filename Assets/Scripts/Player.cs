using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;
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

    public Material comSalto;
    public Material semSalto;

    [HideInInspector]
    public bool canJump;
    private bool couldJump;

    [HideInInspector]
    public bool canPlay;
    private bool isDead;

    [HideInInspector]
    public bool wonGame;

    public AudioClip sfxJump;
    public AudioClip sfxRefresh;
    public AudioClip sfxDie;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        spawn = transform.position;
        canJump = true;
        couldJump = true;
        canPlay = true;
        isDead = false;
        wonGame = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canPlay && !wonGame)
        {
            float horizontalValue = Input.GetAxisRaw("Horizontal");
            float verticalValue = Input.GetAxisRaw("Vertical");

            forward = new Vector3(
                camera.transform.forward.x,
                0.0f,
                camera.transform.forward.z
            ).normalized;
            right = new Vector3(
                camera.transform.right.x,
                0.0f,
                camera.transform.right.z
            ).normalized;

            if (_rigidBody.velocity.magnitude >= limitV)
            {
                _rigidBody.velocity = _rigidBody.velocity.normalized * limitV;
            }
            else
            {
                _rigidBody.AddForce(forward * speed * verticalValue);
                _rigidBody.AddForce(right * speed * horizontalValue);
            }

            if (Input.GetButton("Jump") && canJump)
            {
                _rigidBody.AddForce(Vector3.up * height, ForceMode.Impulse);
                canJump = false;
            }
            else
            {
                _rigidBody.AddForce(Vector3.down * gravity);
            }
            //se carregou no alt, reduz a sua velocidade por metade
            if (Input.GetButton("Fire1"))
            {
                _rigidBody.velocity = new Vector3(
                    _rigidBody.velocity.x * brake,
                    _rigidBody.velocity.y,
                    _rigidBody.velocity.z * brake
                );
            }
        }
        else if (wonGame)
        {
            _rigidBody.velocity = new Vector3(
                _rigidBody.velocity.x * 0.99f,
                _rigidBody.velocity.y + 0.2f,
                _rigidBody.velocity.z * 0.99f
            );
        }
    }

    void Update()
    {
        if (!isDead && transform.position.y < -50)
        {
            isDead = true;
            source.clip = sfxDie;
            source.Play();
            Kill();
        }

        if (!canJump && couldJump)
        {
            source.clip = sfxJump;
            source.Play();
            GetComponent<MeshRenderer>().material = semSalto;
            couldJump = false;
        }
        else if (canJump && !couldJump)
        {
            source.clip = sfxRefresh;
            source.Play();
            GetComponent<MeshRenderer>().material = comSalto;
            couldJump = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        canJump = true;
    }

    public void Kill()
    {
        camera.canMove = false;
        canPlay = false;
        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = spawn;
        _rigidBody.velocity = new Vector3();
        _rigidBody.angularVelocity = new Vector3();
        canPlay = true;
        isDead = false;
        camera.canMove = true;
        camera.transform.position = transform.position + Vector3.up * 1 + Vector3.right * 30;
    }

    public void WinCutscene()
    {
        camera.canMove = false;
        canPlay = false;
        wonGame = true;
    }

    public Vector3 getVelocity()
    {
        return _rigidBody.velocity;
    }
}
