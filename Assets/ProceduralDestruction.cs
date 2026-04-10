using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralDestruction : MonoBehaviour
{
    public float radioExplosion = 5.0f; // Radio de la explosión
    public int subdivisionDepth = 3; // Número de subdivisiones para la destrucción



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestruccionProcedural();
        }
    }



    void DestruccionProcedural()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < subdivisionDepth; i++)
        {
            SubdividirTriangulos(vertices, triangles);
        }

        mesh.vertices = vertices;       
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    void SubdividirTriangulos(Vector3[] vertices, int[] triangles)
    {
        List<Vector3> newVertices = new List<Vector3>();
        List<int> newTriangles = new List<int>();

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];

            Vector3 centro = (p1 + p2 + p3) / 3;
            float distancia = Vector3.Distance(centro, transform.position);

            if (distancia <= radioExplosion)
            {
                Vector3 medio12 = (p1 + p2) / 2;
                Vector3 medio23 = (p2 + p3) / 2;
                Vector3 medio31 = (p3 + p1) / 2;

                newVertices.Add(p1);
                newVertices.Add(medio12);
                newVertices.Add(centro);

                newVertices.Add(medio12);
                newVertices.Add(p2);
                newVertices.Add(medio23);

                newVertices.Add(medio23);
                newVertices.Add(p3);
                newVertices.Add(centro);

                newVertices.Add(medio31);
                newVertices.Add(medio23);
                newVertices.Add(centro);

                newTriangles.Add(newVertices.Count - 3);
                newTriangles.Add(newVertices.Count - 2);
                newTriangles.Add(newVertices.Count - 1);

                newTriangles.Add(newVertices.Count - 6);
                newTriangles.Add(newVertices.Count - 5);
                newTriangles.Add(newVertices.Count - 4);

                newTriangles.Add(newVertices.Count - 9);
                newTriangles.Add(newVertices.Count - 8);
                newTriangles.Add(newVertices.Count - 7);

                newTriangles.Add(newVertices.Count - 12);
                newTriangles.Add(newVertices.Count - 11);
                newTriangles.Add(newVertices.Count - 10);
            }
            else
            {
                newTriangles.AddRange(new int[] { triangles[i], triangles[i + 1], triangles[i + 2] });
            }
        }

        vertices = newVertices.ToArray();
        triangles = newTriangles.ToArray();
    }



}
