using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Trap_Mesh_Generator : MonoBehaviour
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
            //Inner Square
            new Vector3 (0f, 0.1f, 0f), //Bottom-left (0)
            new Vector3 (0f, 0.1f, 1f), //Top-left (1)
            new Vector3 (1f, 0.1f, 0f), //Bottom-right (2)
            new Vector3 (1f, 0.1f, 1f), //Top-right (3)

            //Outer Square
            new Vector3 (-0.2f, 0f, -0.2f), //Bottom-left (4)
            new Vector3 (-0.2f, 0f, 1.2f), //Top-left (5)
            new Vector3 (1.2f, 0f, -0.2f), //Bottom-right (6)
            new Vector3 (1.2f, 0f, 1.2f) //Top-right (7)
        };

        triangles = new int[]
        {
            //Inner Square Face
            0, 1, 2,
            1, 3, 2,

            //Outer Square Face
            4, 5, 6,
            5, 7, 6,

            //South Face
            4, 0, 6,
            0, 2, 6,

            //West Face
            1, 0, 4,
            5, 1, 4,

            //North Face
            3, 1, 5,
            7, 3, 5,

            //East Face
            2, 3, 7,
            6, 2, 7
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
