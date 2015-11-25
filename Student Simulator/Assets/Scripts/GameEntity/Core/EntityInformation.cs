using Entity;
using StudentSimulator.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

public class EntityInformation : MonoBehaviour
{
    public UInt64 Id;

    public string Name;

    public string PrefabName;

    [HideInInspector]
    public string FullName;
}

[CustomEditor(typeof(EntityInformation))]
public class EntityInformationEditor : Editor
{
    string[] EntityTypes
    {
        get
        {
            return Assembly.GetAssembly(typeof(GameEntity)).
                GetTypes().
                Where(type => type.GetCustomAttributes(typeof(EntityAttribute), false).Any()).
                Select(type => type.FullName).ToArray();
        }
    }
    int selectedItem = 0;

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();
        selectedItem = EditorGUILayout.Popup(selectedItem, EntityTypes);
        var someClass = target as EntityInformation;

        someClass.FullName = EntityTypes[selectedItem];
        EditorUtility.SetDirty(target);
    }
}