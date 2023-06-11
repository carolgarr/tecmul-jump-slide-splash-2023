using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    
    [HideInInspector]
    public  Vector3 offset;

    public bool canMove;
    public bool canLook;

    void Start()
    {
        //distancia do jogador à camara
        offset = new Vector3(7f, 7f, 0f);

        canMove = true;
        canLook = true;
    }

    //corre sempre depois de todos os Updates
    //para olhar para o jogador depois de se mover do update
    void LateUpdate()
    {
        if (canMove)
        {
            //segue o jogador
            transform.position = player.position + offset;
            if (canLook)
            {
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2.0f, Vector3.up) * offset;
            }
        }

        //a camara olha para um ponto imaginario diretamente acima do jogador
        transform.LookAt(player.position + Vector3.up * 3);
    }
}
