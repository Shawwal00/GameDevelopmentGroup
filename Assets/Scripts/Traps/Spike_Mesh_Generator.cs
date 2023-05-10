using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Spike_Mesh_Generator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            //Square Base
            new Vector3 (0f, 0f, 0f), //Bottom-left (0)
            new Vector3 (0f, 0f, 1f), //Top-left (1)
            new Vector3 (1f, 0f, 0f), //Bottom-right (2)
            new Vector3 (1f, 0f, 1f), //Top-right (3)

            //Tip
            new Vector3 (0.5f, 3f, 0.5f), //(4)
        };

        triangles = new int[]
        {
            //Inner Square Face
            0, 1, 2,
            1, 3, 2,

            //Sides
            0, 4, 1,
            1, 4, 3,
            3, 4, 2,
            2, 4, 0
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
