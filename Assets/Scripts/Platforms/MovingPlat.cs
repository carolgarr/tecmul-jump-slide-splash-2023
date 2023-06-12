using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public float distanciaMax;
    public float velocidade;

    private Vector3 posInicial;
    private Vector3 eixo;
    private bool moverParaFrente;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        eixo = transform.forward;
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
