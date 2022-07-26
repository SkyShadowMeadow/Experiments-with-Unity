using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CustomWindow : EditorWindow
    {
        [MenuItem("Tools/CustomEditor")]
        public static void OpenWindow()
        {
            EditorWindow windowToOpen = GetWindow<CustomWindow>();
            var content = new GUIContent("Custom window");
        }
    }
}
