/*****************************************************************************
// File Name :         FieldOfView.cs
// Author :            Kyle Grenier
// Creation Date :     09/12/2021
//
// Brief Description : Creates a field of view effect via dynamic mesh creation.
*****************************************************************************/
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask whatToHit;
    private Mesh mesh;

    private Vector3 origin;
    private float startingAngle;
    private float fov;

    [SerializeField] private float viewDistance;

    private void Start()
    {
        mesh = new Mesh();
        origin = Vector3.zero;
        startingAngle = 0f;
        fov = 90f;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void LateUpdate()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; ++i)
        {
            float angleRad = angle * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Vector3 vertex;

            RaycastHit2D hit = Physics2D.Raycast(origin, dir, viewDistance, whatToHit);
            if (hit.collider == null)
            {
                // If we didn't hit anything, place the vertex
                // where it should be (max distance).
                vertex = origin + dir * viewDistance;
            }
            else
            {
                // If we did hit, place the vertex on the hit point.
                vertex = hit.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            // If we increse, we'll be increasing the angle in the 
            // CCW direction, so we'll decrease to go in the CW direction.
            angle -= angleIncrease;
            vertexIndex++;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        Vector3 dir = aimDirection.normalized;
        float vecToAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (vecToAngle < 0)
        {
            vecToAngle += 360f;
        }

        startingAngle = vecToAngle - fov / 2f;
    }
}