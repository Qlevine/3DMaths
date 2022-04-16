using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DrawShape))]
public class DrawShapeEditor : Editor
{
    SerializedProperty showCrossProducts;
    SerializedProperty showMagnitudes;

    private void OnEnable()
    {
        showCrossProducts = serializedObject.FindProperty("showCrossProducts");
        showMagnitudes = serializedObject.FindProperty("showMagnitudes");
    }

    public override void OnInspectorGUI()
    {
        bool oldCrossVal = showCrossProducts.boolValue, oldMagnitudeVal = showMagnitudes.boolValue;
        
        base.OnInspectorGUI();
        serializedObject.Update();
        serializedObject.ApplyModifiedProperties();
        if(oldCrossVal != showCrossProducts.boolValue || oldMagnitudeVal != showMagnitudes.boolValue)
        {
            DrawShape drawShape = (DrawShape)target;
            drawShape.ForceUpdate();
        }
    }
}
