using System;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public PolygonCollider2D hole2Dcolider;
    public PolygonCollider2D ground2Dcollider;
    public MeshCollider generateMeshCollider;
    public Collider GroundCollider;
    Mesh GenerateMesh;

    public float initialScale = 0.5f;
    public float _speed=5f;
    private void Start()
    {
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacies");
        foreach (var item in Obstacles)
        {
            Physics.IgnoreCollision(item.GetComponent<Collider>(), generateMeshCollider,true);
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

    private Vector3 input;
    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        transform.position += input * Time.fixedDeltaTime * _speed;
        if(transform.hasChanged)
        {
            transform.hasChanged = false;
            hole2Dcolider.transform.position = new Vector2(transform.position.x,transform.position.z);
            hole2Dcolider.transform.localScale = transform.localScale * initialScale;
            HoleMake();
            MakeMeshCollider();
        }
    }
    private void HoleMake()
    {
        Vector2[] pointsPos = hole2Dcolider.GetPath(0);
        for (int i = 0; i < pointsPos.Length; i++)
        {
            pointsPos[i] = hole2Dcolider.transform.TransformPoint(pointsPos[i]);

        }
        ground2Dcollider.pathCount = 2;
        ground2Dcollider.SetPath(1,pointsPos);
    }
    private void MakeMeshCollider()
    {
        if (GenerateMesh != null)
            Destroy(GenerateMesh);

        GenerateMesh = ground2Dcollider.CreateMesh(true, true);
        generateMeshCollider.sharedMesh = GenerateMesh;
    }
   
}
