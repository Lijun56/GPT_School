using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LoginSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is for connecting to photon server",MessageType.Info);
        LoginManager loginManager =(LoginManager)target;
        if(GUILayout.Button("join Anonymus")){
            loginManager.ConnectAnonymusly();
        }
    }
}
