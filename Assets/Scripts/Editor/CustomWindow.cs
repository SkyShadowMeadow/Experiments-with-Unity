using System;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Editor
{
    public class CustomWindow : EditorWindow
    {
        private SearchField _searchField;
        private String _findRequest;
        
        [MenuItem("Tools/CustomEditor")]
        public static void OpenWindow()
        {
            EditorWindow windowToOpen = GetWindow<CustomWindow>();
            var content = new GUIContent("Custom window");
        }

        public void CreateGUI()
        {
            _searchField = new SearchField();
        }

        private void OnGUI()
        {
            var newFindRequest = _searchField?.OnToolbarGUI(_findRequest);
        }
    }
}
