using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAxes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);
        //Draw X axis
        GL.Color(Color.red);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(3.0f, 0.0f, 0.0f);
        //Draw Y axis
        GL.Color(Color.green);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(0.0f, -3.0f, 0.0f);
        //Draw Z axis
        GL.Color(Color.blue);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(0.0f, 0.0f, 3.0f);
        GL.End();
        GL.PopMatrix();
    }
}
