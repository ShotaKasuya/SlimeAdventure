using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor
{
    [CustomEditor(typeof(SortableScriptableObject), true)]
    [CanEditMultipleObjects]
    public class SortableScriptableObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SortableScriptableObject scriptableObject = (SortableScriptableObject)target;

            if (GUILayout.Button("Sort List"))
            {
                scriptableObject.Sort();
                EditorUtility.SetDirty(scriptableObject);
            }

            if (GUI.changed)
            {
                scriptableObject.Sort();
                EditorUtility.SetDirty(scriptableObject);
            }
        }
    }
}