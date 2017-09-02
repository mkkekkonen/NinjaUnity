using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraBounds))]
public class CameraBoundsEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraBounds cb = (CameraBounds)target;

        if (GUILayout.Button("Set Min Pos"))
            cb.SetMinPos();

        if (GUILayout.Button("Set Max Pos"))
            cb.SetMaxPos();
    }
}
