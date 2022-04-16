using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShape : MonoBehaviour
{
    public Vector3[] points;
    public Color[] colors;

    private void Start()
    {
        drawTriangle = new DrawTriangle(points, colors);
    }
    private void OnDrawGizmos()
    {
        DrawMyTriangle();
    }

    DrawTriangle drawTriangle;
    private void DrawMyTriangle()
    {
        if(points.Length != 3)
        {
            return;
        }
        if (drawTriangle == null)
        {
            drawTriangle = new DrawTriangle(points, colors);
        }
        else
        {
            drawTriangle.lineColors = colors;
            drawTriangle.DrawTriangleEdges();
        }
        
    }
}
