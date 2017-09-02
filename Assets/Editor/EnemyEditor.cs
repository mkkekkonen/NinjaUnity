using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Enemy enemy = (Enemy)target;

        if (GUILayout.Button("Set Left Bound"))
            enemy.SetLeftBound();

        if (GUILayout.Button("Set Right Bound"))
            enemy.SetRightBound();
    }
}
