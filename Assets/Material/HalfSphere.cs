using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HalfSphere : MonoBehaviour
{
    [Range(4, 64)] public int longitudeSegments = 32; // 가로 분할 수
    [Range(2, 32)] public int latitudeSegments = 16;  // 세로 분할 수
    public float radius = 1f;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = CreateHemisphere(radius, longitudeSegments, latitudeSegments);
    }

    Mesh CreateHemisphere(float radius, int longSeg, int latSeg)
    {
        Mesh mesh = new Mesh();
        mesh.name = "Hemisphere";

        int vertCount = (latSeg + 1) * (longSeg + 1);
        Vector3[] vertices = new Vector3[vertCount];
        Vector3[] normals = new Vector3[vertCount];
        Vector2[] uv = new Vector2[vertCount];
        int[] triangles = new int[latSeg * longSeg * 6];

        int vertIndex = 0;
        int triIndex = 0;

        for (int lat = 0; lat <= latSeg; lat++)
        {
            float a1 = Mathf.PI * 0.5f * lat / latSeg; // 반구니까 0~PI/2
            float sin1 = Mathf.Sin(a1);
            float cos1 = Mathf.Cos(a1);

            for (int lon = 0; lon <= longSeg; lon++)
            {
                float a2 = 2 * Mathf.PI * lon / longSeg;
                float sin2 = Mathf.Sin(a2);
                float cos2 = Mathf.Cos(a2);

                Vector3 normal = new Vector3(sin1 * cos2, cos1, sin1 * sin2);
                vertices[vertIndex] = normal * radius;
                normals[vertIndex] = normal;
                uv[vertIndex] = new Vector2((float)lon / longSeg, (float)lat / latSeg);

                if (lat < latSeg && lon < longSeg)
                {
                    int current = vertIndex;
                    int next = current + longSeg + 1;

                    triangles[triIndex++] = current;
                    triangles[triIndex++] = next;
                    triangles[triIndex++] = current + 1;

                    triangles[triIndex++] = current + 1;
                    triangles[triIndex++] = next;
                    triangles[triIndex++] = next + 1;
                }

                vertIndex++;
            }
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }
}
