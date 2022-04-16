using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShape : MonoBehaviour
{
    public Vector3[] points;
    public Color[] colors;

    [SerializeField]
    private bool showCrossProducts;

    [SerializeField]
    private bool showMagnitudes;

    [SerializeField]
    private bool showDotProducts;

    private void Start()
    {
        drawTriangle = new DrawTriangle(points, colors);
    }
    [SerializeField]
    private bool forceUpdate = false;
    private void OnDrawGizmos()
    {
        if (forceUpdate)
        {
            forceUpdate = false;
            DrawMyTriangle(true);
        }
        else
        {
            DrawMyTriangle(false);
        }
        
    }

    DrawTriangle drawTriangle;
    private void DrawMyTriangle(bool forceUpdate)
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
            drawTriangle.DrawTriangleEdges(showCrossProducts,showMagnitudes,showDotProducts,forceUpdate);
            forceUpdate = false;
        }
    }

    public void ForceUpdate()
    {
        forceUpdate = true;
    }
}
