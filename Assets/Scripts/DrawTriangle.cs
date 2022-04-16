using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTriangle
{
    public Vector3[] vectors { get; set; }
    public Color[] lineColors { get; set; }

    public List<DrawLine> drawLines = new List<DrawLine>();

    private Vector3[] oldPoints = new Vector3[3];
    private Color[] oldColors = new Color[3];

    public DrawTriangle(Vector3[] points, Color[] lineColors = null)
    {
        this.vectors = points;
        this.lineColors = lineColors;
    }

    public void DrawTriangleEdges(bool showCrossProducts, bool showMagnitudes, bool showDotProduct, bool forceUpdate = false)
    {
        if (vectors.Length != 3)
        {
            Debug.LogError("DrawTriangle only supports three points");
            return;
        }
        if (lineColors == null)
        {
            lineColors = new Color[] { Color.black, Color.black, Color.black };
        }

        if (forceUpdate || drawLines == null || CheckForChange(oldPoints,vectors) || CheckForChange(oldColors,lineColors))
        {
            drawLines.Clear();
            DrawLine line1 = new DrawLine(vectors[0], vectors[1], lineColors[0]);
            DrawLine line2 = new DrawLine(vectors[1], vectors[2], lineColors[1]);
            DrawLine line3 = new DrawLine(vectors[0], vectors[2], lineColors[2]);

            drawLines.AddRange(new DrawLine[]{ line1,line2,line3});

            Vector3 crossProd1 = MathUtility.CrossProduct(vectors[0], vectors[1]);
            Vector3 crossProd2 = MathUtility.CrossProduct(vectors[1], vectors[2]);
            Vector3 crossProd3 = MathUtility.CrossProduct(vectors[0], vectors[2]);

            if (showCrossProducts)
            {
                DrawLine crossProdLine1 = new DrawLine(vectors[0], crossProd1, new Color(1, 1, 1, 0.2f));
                DrawLine crossProdLine2 = new DrawLine(vectors[1], crossProd2, new Color(1, 1, 1, 0.2f));
                DrawLine crossProdLine3 = new DrawLine(vectors[2], crossProd3, new Color(1, 1, 1, 0.2f));
                drawLines.AddRange(new DrawLine[] { crossProdLine1, crossProdLine2, crossProdLine3 });
            }


            double magnitude1 = MathUtility.Magnitude(vectors[1] - vectors[0]);
            double magnitude2 = MathUtility.Magnitude(vectors[2] - vectors[1]);
            double magnitude3 = MathUtility.Magnitude(vectors[0] - vectors[2]);

            if (showMagnitudes)
            {
                DrawLine magnitudeLine1 = new DrawLine(Vector3.zero, new Vector3((float)magnitude1, 0, 0), lineColors[0]);
                DrawLine magnitudeLine2 = new DrawLine(Vector3.zero, new Vector3(0, (float)magnitude2, 0), lineColors[1]);
                DrawLine magnitudeLine3 = new DrawLine(Vector3.zero, new Vector3(0, 0, (float)magnitude3), lineColors[2]);
                drawLines.AddRange(new DrawLine[] { magnitudeLine1, magnitudeLine2, magnitudeLine3 });
            }

            MathUtility.DotProduct(vectors[0], vectors[1]);
            MathUtility.DotProduct(vectors[1], vectors[2]);
            MathUtility.DotProduct(vectors[0], vectors[2]);
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
