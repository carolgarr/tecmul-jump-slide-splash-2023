using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player player;

    private GameController GameController;

    [HideInInspector]
    public bool canMove;
    public bool canLook;

    private Vector3 offset;

    public float rotationSpeed = 9.0f; // Velocidade de rotação da câmera
    private float rotationX = 0.0f; // Rotação da câmera no eixo X
    private float rotationY = 0.0f; // Rotação da câmera no eixo Y

    void Start()
    {
        canMove = true;
        canLook = true;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    /*
    //########################################################################################
    //DEBUG
    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    public float m_refreshTime = 1f;
    void Update()
    {
        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        { //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }
        Debug.Log(m_lastFramerate);
    }
    //########################################################################################
    */

    void FixedUpdate()
    {
        if (canMove)
        {
            if (!Input.GetMouseButton(0))
            {
                Vector3 newPosition = player.transform.position + getVetorOffset();
                float distancia = Vector3.Distance(transform.position, newPosition);
                float tempo = 0.012f;
                float velocidadeJogador = new Vector3(
                    player.getVelocity().x,
                    player.getVelocity().y * 2,
                    player.getVelocity().z
                ).magnitude;

                if (velocidadeJogador < 0.5f)
                {
                    velocidadeJogador = 0.5f;
                }

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    newPosition,
                    distancia * tempo * velocidadeJogador
                );
            }
        }
    }

    //corre sempre depois de todos os Updates
    //para olhar para o jogador depois de se mover do update
    void LateUpdate()
    {
        if (Input.GetMouseButton(0) && canLook)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            rotationX -= mouseY * rotationSpeed;
            rotationY += mouseX * rotationSpeed;
            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        }
        else
        {
            transform.LookAt(player.transform.position + Vector3.up * 1.5f);
        }
    }

    public Vector3 getVetorOffset()
    {
        Vector3 velocidade = player.getVelocity();
        Vector3 vetor;
        vetor = new Vector3(-velocidade.x, 0, -velocidade.z).normalized * 5 + Vector3.up * 5;
        return vetor;
    }
}
