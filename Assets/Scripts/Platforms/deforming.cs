using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deforming : MonoBehaviour
{
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
    }

    private void OnCollisionEnter(Collision other){
        if (other.collider.name == "Player")
        {
            Vector3 pos = transform.InverseTransformPoint(other.GetContact(0).point);
            Vector3 nrm = transform.InverseTransformDirection(other.GetContact(0).normal);
            DeformPlane(pos,nrm);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
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
        mc.sharedMesh=m;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {
        m.vertices = iVerts;
        }
    }
}
