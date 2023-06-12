using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float velocidade = 1f;
	public float anguloLimite = 60f; //em graus

	void Start()
    {
        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		float angulo = anguloLimite * Mathf.Sin(Time.time + velocidade);
		transform.localRotation = Quaternion.Euler(0, 0, angulo);
	}
}
