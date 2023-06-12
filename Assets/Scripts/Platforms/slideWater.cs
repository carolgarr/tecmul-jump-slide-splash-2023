using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideWater : MonoBehaviour
{
    public float speed;
    GameObject splash;
    GameObject splashObj;

    private Mesh m;
    private MeshCollider mc;
	private Vector3[] verts;
	private Vector3[] iVerts;
    public float malleability;
	public float radius;

    void Start(){
        m = GetComponent<MeshFilter>().mesh;
		mc = GetComponent<MeshCollider>();
        iVerts = m.vertices;
        splash =  GameObject.Find("Particle System");
    }

    private void OnCollisionEnter(Collision other){
        if (other.collider.name == "Player")
        {
            Vector3 splashPosition = other.transform.position + new Vector3(0f, -0.5f, 0f);
            splashObj = Instantiate(splash, splashPosition, Quaternion.identity);
           
           
            Vector3 pos = transform.InverseTransformPoint(other.GetContact(0).point);
            Vector3 nrm = transform.InverseTransformDirection(other.GetContact(0).normal);
            DeformPlane(pos,nrm);
            
        
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Player")
        {

            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            player.AddForce(-transform.right *speed);
            
            Vector3 splashPosition = collision.transform.position + new Vector3(0f, -0.5f, 0f);
            splashObj.transform.position = splashPosition;

            Vector3 pos = transform.InverseTransformPoint(collision.GetContact(0).point);
            Vector3 nrm = transform.InverseTransformDirection(collision.GetContact(0).normal);
            DeformPlane(pos,nrm);
            
        }
    }

    private void DeformPlane(Vector3 pos,Vector3 nrm)
    {
        verts = m.vertices;
        for (int i = 0; i < verts.Length; i++)
        {
            float scale = Mathf.Clamp(radius - (pos - verts[i]).magnitude, 0, radius);
            verts[i] += nrm * scale * malleability;
        }

        m.vertices = verts;
        m.RecalculateNormals();
        

        
       
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {
           Destroy(splashObj, 1.0f);
            m.vertices = iVerts;
        }
    }
}
