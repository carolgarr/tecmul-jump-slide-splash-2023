using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player player;

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

    void FixedUpdate(){
        if (canMove)
        {
            if (!Input.GetMouseButton(0))
            {          
                Vector3 newPosition = player.transform.position + getVetorOffset();
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    newPosition,
                    Vector3.Distance(transform.position, newPosition) * Time.deltaTime + 0.2f
                );
            }
        }
    }

    //corre sempre depois de todos os Updates
    //para olhar para o jogador depois de se mover do update
    void LateUpdate()
    {
        if(Input.GetMouseButton(0) && canLook){
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;
            rotationX -= mouseY * rotationSpeed;
            rotationY += mouseX * rotationSpeed;
            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        }
        else{
            transform.LookAt(player.transform.position + Vector3.up * 2);
        {     
    }

    public Vector3 getVetorOffset()
    {
        Vector3 velocidade = player.getVelocity();
        Vector3 vetor;
        vetor =
            new Vector3(-velocidade.x, 0, -velocidade.z).normalized * 5
            + Vector3.up * 4;
        return vetor;
    }
}
