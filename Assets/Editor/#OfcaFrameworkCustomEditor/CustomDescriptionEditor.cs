using UnityEditor;
using UnityEngine;

namespace OfcaFramework.CustomDescription
{
    [CustomEditor(typeof(CustomDescriptionComponent))]
    public class CustomDescriptionEditor : Editor
    {
        private bool isEditing = false;

        public override void OnInspectorGUI()
        {

            CustomDescriptionComponent customDescriptionComponent = (CustomDescriptionComponent)target;


            EditorGUILayout.LabelField("Custom Description:");


            if (isEditing)
            {

                customDescriptionComponent.customDescription.description = EditorGUILayout.TextArea(customDescriptionComponent.customDescription.description, GUILayout.Height(60));


                if (GUILayout.Button("Accept"))
                {
                    isEditing = false;
                    GUI.FocusControl(null);
                }
            }
            else
            {
                GUIStyle wordWrappedLabel = EditorStyles.wordWrappedLabel;
                float labelHeight = wordWrappedLabel.CalcHeight(new GUIContent(customDescriptionComponent.customDescription.description), EditorGUIUtility.currentViewWidth - 40);

                EditorGUILayout.LabelField(customDescriptionComponent.customDescription.description, wordWrappedLabel, GUILayout.Height(labelHeight));

                var rect = GUILayoutUtility.GetLastRect();
                if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
                {
                    isEditing = true;
                    Event.current.Use();
                }
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }
    }
}