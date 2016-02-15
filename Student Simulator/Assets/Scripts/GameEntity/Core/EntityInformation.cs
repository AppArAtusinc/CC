using Entites;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EntityInformation : MonoBehaviour
{
    public Guid Id;

    public string Name
    {
        get { return gameObject.name; }
        set { gameObject.name = value; }
    }

    public string PrefabName;

    [HideInInspector]
    public string FullName;
}
#if UNITY_EDITOR

[CustomEditor(typeof(EntityInformation))]
public class EntityInformationEditor : Editor
{
    List<string> EntityTypes
    {
        get
        {
            return Assembly.GetAssembly(typeof(GameEntity)).
                GetTypes().
                Where(type => type.GetCustomAttributes(typeof(EntityAttribute), false).Any()).
                Select(type => type.FullName).ToList();
        }
    }
    int selectedItem = 0;

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();
        var someClass = target as EntityInformation;

        selectedItem = this.EntityTypes.IndexOf(someClass.FullName);
        selectedItem = EditorGUILayout.Popup(selectedItem, EntityTypes.ToArray());

        someClass.FullName = EntityTypes[selectedItem];
        EditorUtility.SetDirty(target);
    }
}
#endif
