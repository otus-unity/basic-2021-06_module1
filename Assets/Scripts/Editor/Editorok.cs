using UnityEditor;
using UnityEngine;

class Editorok : EditorWindow
{
    private string myString;
    private bool groupEnabled;
    private bool myBool;
    private float myFloat;

    [MenuItem("Window/Editor")]
    public static void ShowWindow() => EditorWindow.GetWindow(typeof(Editorok));

    void OnGUI()
    {
        GUILayout.Label("Редактор", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
        if(GUILayout.Button("Go"))
            Debug.Log($"myFloat={myFloat}, myString={myString}");
        Camera.main.transform.position = new Vector3(myFloat, 0, 0);
    }
}
