
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class MeshUtil : MonoBehaviour {
    public Mesh mesh;

    public float cutValue = 0;
    [ContextMenu("CutMesh")]
    public void CutMesh()
    {
        Vector3[] vertices = mesh.vertices;

        List<int> removeV = new List<int>();
        for (int i = 0; i < vertices.Length; i++)
        {
            

            if (vertices[i].z < cutValue)
            {
                removeV.Add(i);
            }
        }
        int[] triangles = mesh.triangles;
        List<int> newTriangles = new List<int>();
        for (int i=0;i<triangles.Length; i+=3)
        {
            if(removeV.Contains(triangles[i])||removeV.Contains(triangles[i+1])||removeV.Contains(triangles[i+2]))
            {

            }else
            {
                newTriangles.Add(triangles[i]);
                newTriangles.Add(triangles[i+1]);
                newTriangles.Add(triangles[i+2]);
            }
        }
        

        Mesh newMesh = new Mesh();
        newMesh.vertices = vertices;
        newMesh.uv = mesh.uv;
        newMesh.triangles = newTriangles.ToArray();
        newMesh.normals = mesh.normals;

        string filePath = EditorUtility.SaveFilePanelInProject("Save Procedural Mesh", "Procedural Mesh", "asset", "");
        AssetDatabase.CreateAsset(newMesh, filePath);
    }

    [ContextMenu("getMaxMinY")]
    public void GetMaxY()
    {
        Vector3[] vertices = mesh.vertices;
        float maxY = 0;
        float minY = 0;
        float maxZ = 0;
        float minZ = 0;
        float maxX = 0;
        float minX = 0;
        for(int i=0;i<vertices.Length;i++)
        {
            if(vertices[i].y>maxY)
            {
                maxY = vertices[i].y;
            }
            if(vertices[i].y<minY)
            {
                minY = vertices[i].y;
            }

            if (vertices[i].z > maxZ)
            {
                maxZ = vertices[i].z;
            }
            if (vertices[i].z < minZ)
            {
                minZ = vertices[i].z;
            }
            if (vertices[i].x > maxX)
            {
                maxX = vertices[i].x;
            }
            if (vertices[i].x < minX)
            {
                minX = vertices[i].x;
            }
        }
        Debug.Log("maxY is :"+maxY+" minY is :"+minY);
    }
	// Use this for initialization
	void Start () {
		
	}
	
}
#endif