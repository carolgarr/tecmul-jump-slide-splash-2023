using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves : MonoBehaviour
{
    Mesh mesh;
    Vector3[] verts;
    MeshCollider MeshCol;
    public float SinVal;
    // Start is called before the first frame update
    void Start()
    {
        mesh= GetComponent<MeshFilter>().mesh;
        verts=mesh.vertices;
        MeshCol=GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<verts.Length;i++){
            verts[i].y = Mathf.Sin(SinVal * i + Time.time);
        }
        mesh.vertices=verts;
        mesh.RecalculateBounds();
        MeshCol.sharedMesh=mesh;
    }
}
