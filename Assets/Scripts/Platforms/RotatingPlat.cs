using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EixoEnum
{
    X,
    Y,
    Z
}

public class RotatingPlat : MonoBehaviour
{
    public float velocidade;
    public EixoEnum eixoRotacao;

    private Vector3 eixo;

    // Start is called before the first frame update
    void Start() {
        switch(eixoRotacao){
            case EixoEnum.X:
                eixo = Vector3.right;
                break;
            case EixoEnum.Y: 
                eixo = Vector3.up;
                break;
            case EixoEnum.Z: 
                eixo = Vector3.forward;
                break;
        }
    }

    void FixedUpdate()
    {
        //roda à volta do eixo
        //é vezes 90 para a 'velocidade' ser o nº de rotações por cada 4 segundos
        transform.Rotate(eixo * velocidade * Time.deltaTime * 90f, Space.Self);
    }
}


