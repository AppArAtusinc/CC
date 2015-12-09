using Entity;
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class EntityInformation : MonoBehaviour
{
    public UInt64 Id;

    public string Name
    {
        get { return gameObject.name; }
        set { gameObject.name = value; }
    }

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