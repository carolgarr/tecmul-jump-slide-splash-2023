using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EixoEnum1
{
    X,
    Y,
    Z
}

public class MovingPlat : MonoBehaviour
{
    public float distanciaMax;
    public float velocidade;
    public EixoEnum1 eixoMovimento;
    public bool relativoAoMundo = true;

    private Vector3 posInicial;
    private Vector3 eixo;
    private bool moverParaFrente;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        if(relativoAoMundo){
        switch(eixoMovimento){
            case EixoEnum1.X:
                eixo = Vector3.right;
                break;
            case EixoEnum1.Y: 
                eixo = Vector3.up;
                break;
            case EixoEnum1.Z: 
                eixo = Vector3.forward;
                break;
        }
        }
        else{
        switch(eixoMovimento){
            case EixoEnum1.X:
                eixo = transform.right;
                break;
            case EixoEnum1.Y: 
                eixo = transform.up;
                break;
            case EixoEnum1.Z: 
                eixo = transform.forward;
                break;
        }

        }
        moverParaFrente = true;
    }

    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, posInicial) > distanciaMax){
           moverParaFrente = !moverParaFrente;
        }
        
        if(moverParaFrente){
            transform.position +=  velocidade * eixo * Time.deltaTime;
        }
        else {
            transform.position += -velocidade * eixo * Time.deltaTime;
        }
    }
}
