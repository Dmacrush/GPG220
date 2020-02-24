using Pathfinding.Boids.Behaviour_Scripts;
using UnityEditor;
using UnityEngine;

namespace BoidsEditor
{
    [CustomEditor(typeof(CompositeBehaviour))]
    public class CompositeBehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CompositeBehaviour cb = (CompositeBehaviour) target;
            
            Rect r = EditorGUILayout.BeginHorizontal();
            r.height = EditorGUIUtility.singleLineHeight;
            
            //check for behaviour
            if (cb.behaviours == null || cb.behaviours.Length == 0)
            {
                EditorGUILayout.HelpBox("No Behaviour in array." , MessageType.Warning);
                EditorGUILayout.EndHorizontal();
                
                r = EditorGUILayout.BeginHorizontal();
                r.height = EditorGUIUtility.singleLineHeight;
            }
            else
            {
                r.x = 30f;
                r.width = EditorGUIUtility.currentViewWidth - 95f;
                EditorGUI.LabelField(r,"Behaviours");
                r.x = EditorGUIUtility.currentViewWidth - 65f;
                r.width = 60f;
                EditorGUI.LabelField(r, "Weights");
                r.y += EditorGUIUtility.singleLineHeight * 1.2f;
                
            }
        }
    }
}
