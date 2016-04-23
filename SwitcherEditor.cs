using UnityEngine;
using UnityEditor;

//This is an editor Script for the SwitcherScript

[CustomEditor(typeof(SwitcherScript)), CanEditMultipleObjects]
public class SwitcherEditor : Editor
{
    SerializedProperty useKeySwitch;
    SerializedProperty switchBtn;
    SerializedProperty switchThroughChildren;
    SerializedProperty switchObjs;
    SerializedProperty switchIndex;

    //When the object is enabled in the scene, it steps in here and executes the following code.
    void OnEnable()
    {
        useKeySwitch = serializedObject.FindProperty("useKeySwitch");
        switchBtn = serializedObject.FindProperty("switchBtn");
        switchThroughChildren = serializedObject.FindProperty("switchThroughChildren");
        switchObjs = serializedObject.FindProperty("switchObjs");
        switchIndex = serializedObject.FindProperty("switchIndex");
    }

    //When we click on the object in the scene, it steps into here and executes the following code.
    public override void OnInspectorGUI()
    {
        //Call the generic object property updates
        serializedObject.Update();

        EditorGUILayout.PropertyField(useKeySwitch); //Reveal Use Key Switch Boolean
        bool keySwitch = (bool)useKeySwitch.boolValue;

        //If Key Switch is true reveal the switch Key Code option
        if(keySwitch)
        {
            EditorGUILayout.PropertyField(switchBtn);   //Reveal Switch Button
        }        

        //Cheeky space to make the format look nice
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(switchThroughChildren);   //Reveal switchThroughChildren
        
        bool childSwitch = (bool)switchThroughChildren.boolValue;

        //If Switch Through Children is true than hide the switchObjs array
        if (!childSwitch)
        {
            switchIndex.intValue = EditorGUILayout.IntSlider("Active Object", switchIndex.intValue, 0, switchObjs.arraySize-1);
            EditorGUILayout.PropertyField(switchObjs, GUIContent.none, true);
        }
        else
        {
            switchIndex.intValue = EditorGUILayout.IntField("Active Object", switchIndex.intValue);
        }

        //and finally, after the whole script, apply out changes
        serializedObject.ApplyModifiedProperties();
    }
}