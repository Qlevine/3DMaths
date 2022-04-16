using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MathUtility : MonoBehaviour
{
    public static float DotProduct(Vector3 vectorA, Vector3 vectorB)
    {
        float scalar = (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z);
        //Debug.Log($"DOT PRODUCT: {scalar} for {vectorA} and {vectorB}");
        return scalar;
    }

    public static double Magnitude(Vector3 vectorA)
    {
        double sum = (vectorA.x * vectorA.x) + (vectorA.y * vectorA.y) + (vectorA.z * vectorA.z);
        double mag = Math.Sqrt(sum);
        //Debug.Log($"MAGNITUDE: {mag} for {vectorA}");
        return mag;
    }

    public static Vector3 CrossProduct(Vector3 vectorA, Vector3 vectorB)
    {
        float iA = vectorA[0], jA = vectorA[1], kA = vectorA[2];
        float iB = vectorB[0], jB = vectorB[1], kB = vectorB[2];

        Vector3 crossProd = new Vector3((jA * kB) - (kA * jB), -((iA * kB) - (iB * kA)), (iA * jB) - (iB * jA));
        //Debug.Log($"CROSS PRODUCT 3D: {crossProd} for {vectorA} and {vectorB}");
        return crossProd;
    }

    public static Vector2 CrossProduct(Vector2 vectorA, Vector2 vectorB)
    {
        float iA = vectorA[0], jA = vectorA[1];
        float iB = vectorB[0], jB = vectorB[1];

        Vector2 crossProd = new Vector2(iA * jB, jA * iB);
        //Debug.Log($"CROSS PRODUCT 3D: {crossProd} for {vectorA} and {vectorB}");
        return crossProd;
    }
}
