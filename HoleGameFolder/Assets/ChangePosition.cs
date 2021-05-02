using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public PolygonCollider2D hole2Dcolider;
    public PolygonCollider2D ground2Dcollider;
    public MeshCollider generateMeshCollider;
    public Collider GroundCollider;
    Mesh GenerateMesh;

    public float initialScale = 0.5f;
    private void Start()
    {
        GameObject[] allObs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (var item in allObs)
        {
            if(item.layer==LayerMask.NameToLayer("Obstacies"))
            {
                Physics.IgnoreCollision(item.GetComponent<Collider>(), generateMeshCollider,true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(other, GroundCollider,true);
        Physics.IgnoreCollision(other, generateMeshCollider, false);
    }
    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(other, GroundCollider, false);
        Physics.IgnoreCollision(other, generateMeshCollider, true);
    }
    private void FixedUpdate()
    {
        if(transform.hasChanged==true)
        {
            transform.hasChanged = false;
            hole2Dcolider.transform.position = new Vector2(transform.position.x,transform.position.z);
            hole2Dcolider.transform.localScale = transform.localScale * initialScale;
            holeMake2D();
            make3DMeshCollider();
        }
    }
    private void holeMake2D()
    {
        Vector2[] pointsPos = hole2Dcolider.GetPath(0);
        for (int i = 0; i < pointsPos.Length; i++)
        {
            pointsPos[i] = hole2Dcolider.transform.TransformPoint(pointsPos[i]);

        }
        ground2Dcollider.pathCount = 2;
        ground2Dcollider.SetPath(1,pointsPos);
    }
    private void make3DMeshCollider()
    {
        if (GenerateMesh != null)
            Destroy(GenerateMesh);

        GenerateMesh = ground2Dcollider.CreateMesh(true, true);
        generateMeshCollider.sharedMesh = GenerateMesh;
    }
   
}
