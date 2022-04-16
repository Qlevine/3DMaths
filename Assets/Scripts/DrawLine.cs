using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine
{
    public Vector3 startOfLine { get; set; }
    public Vector3 endOfLine { get; set; }
    public Color lineColor { get; set; }

    public DrawLine(Vector3 startOfLine, Vector3 endOfLine, Color lineColor)
    {
        this.startOfLine = startOfLine;
        this.endOfLine = endOfLine;
        this.lineColor = lineColor;
    }  

    public void DrawLines()
    {
        Debug.DrawLine(startOfLine, endOfLine, lineColor);
    }
}
