using Assets.Scripts.Character.Health;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(HealthComponent))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    private SerializedProperty lookAtPoint;

    void OnEnable()
    {
        lookAtPoint = serializedObject.FindProperty("Target");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(lookAtPoint);
        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.LabelField("(Текст)");
        EditorGUILayout.ColorField(Color.red);
    }
}
