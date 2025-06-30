using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InspectorButton))]
public class IsnpectorButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InspectorButton _inspectorButton = (InspectorButton)target;

        if (GUILayout.Button(_inspectorButton.eventName))
        {
            _inspectorButton.Invoke();
        }
    }
}
