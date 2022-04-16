using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTriangle
{
    public Vector3[] points { get; set; }
    public Color[] lineColors { get; set; }

    public DrawLine[] drawLines;

    private Vector3[] oldPoints = new Vector3[3];
    private Color[] oldColors = new Color[3];

    public DrawTriangle(Vector3[] points, Color[] lineColors = null)
    {
        this.points = points;
        this.lineColors = lineColors;
    }

    public void DrawTriangleEdges()
    {
        if (points.Length != 3)
        {
            Debug.LogError("DrawTriangle only supports three points");
            return;
        }
        if (lineColors == null)
        {
            lineColors = new Color[] { Color.black, Color.black, Color.black };
        }

        if (drawLines == null || CheckForChange(oldPoints,points) || CheckForChange(oldColors,lineColors))
        {
            DrawLine line1 = new DrawLine(points[0], points[1], lineColors[0]);
            DrawLine line2 = new DrawLine(points[1], points[2], lineColors[1]);
            DrawLine line3 = new DrawLine(points[0], points[2], lineColors[2]);


            Vector3 crossProd1 = MathUtility.CrossProduct(points[0], points[1]);
            Vector3 crossProd2 = MathUtility.CrossProduct(points[1], points[2]);
            Vector3 crossProd3 = MathUtility.CrossProduct(points[0], points[2]);

            DrawLine crossProdLine1 = new DrawLine(points[0], crossProd1, new Color(1, 1, 1, 0.2f));
            DrawLine crossProdLine2 = new DrawLine(points[1], crossProd2, new Color(1, 1, 1, 0.2f));
            DrawLine crossProdLine3 = new DrawLine(points[2], crossProd3, new Color(1, 1, 1, 0.2f));

            MathUtility.Magnitude(points[0]);
            MathUtility.Magnitude(points[1]);
            MathUtility.Magnitude(points[2]);

            MathUtility.DotProduct(points[0], points[1]);
            MathUtility.DotProduct(points[1], points[2]);
            MathUtility.DotProduct(points[0], points[2]);

            drawLines = new DrawLine[] { line1, line2, line3,crossProdLine1,crossProdLine2,crossProdLine3 };
        }

        foreach(DrawLine line in drawLines)
        {
            line.DrawLines();
        }
    }

    private bool CheckForChange<T>(T[] oldVersion, T[] newVersion)
    {
        if (oldVersion == null)
        {
            return true;
        }
        for(int i = 0; i < oldVersion.Length; i++)
        {
            if(oldVersion[i].ToString() != newVersion[i].ToString())
            {
                oldVersion[i] = newVersion[i];
                return true;
            }
        }
        return false;
    }
}
