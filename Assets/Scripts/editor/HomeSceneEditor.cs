using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(roommanager))]
public class HomeSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is for connecting to photon server",MessageType.Info);
        roommanager RoomManager =(roommanager)target;
        if(GUILayout.Button("join school")){
            RoomManager.OnEnterButtonClicked_School();
        }
        if(GUILayout.Button("join outdoor")){
            RoomManager.OnEnterButtonClicked_Outdoor();
        }
    }
}
