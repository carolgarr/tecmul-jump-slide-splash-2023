using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	private Player player;
    
    [HideInInspector]
    public  Vector3 offset1;
	[HideInInspector]
 	public  Vector3 offset2;
	[HideInInspector]
 	public  Vector3 offset3;
	[HideInInspector]
	 public  Vector3 offset4;
    [HideInInspector]
    public bool canMove;
    public bool canLook;

	public float rotationSpeed = 9.0f; // Velocidade de rotação da câmera
	private float rotationX = 0.0f; // Rotação da câmera no eixo X
	private float rotationY = 0.0f; // Rotação da câmera no eixo Y

    void Start()
    {
        canMove = true;
		player = GameObject.Find("Player").GetComponent<Player>();
		
    }

    //corre sempre depois de todos os Updates
    //para olhar para o jogador depois de se mover do update
    void LateUpdate()
    {
        if (canMove)
        {
			if(Input.GetMouseButton(1)){
			float mouseX = Input.GetAxis("Mouse X");
  		    float mouseY = Input.GetAxis("Mouse Y");
 			rotationX -= mouseY * rotationSpeed;
   			rotationY += mouseX * rotationSpeed;
			transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
			}

		transform.position = player.transform.position + getVetor();

        }
		transform.LookAt(player.transform.position + Vector3.up * 3);
    }

		public Vector3 getVetor() { 
		Vector3 vetor;
		vetor = new Vector3(-player.getVelocity().x,0,-player.getVelocity().z).normalized*7 + Vector3.up*7;
			return vetor;
		}
}
