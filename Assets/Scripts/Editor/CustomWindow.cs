using System;
using System.Collections.Generic;
using Configuration;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Editor
{
    public class CustomWindow : EditorWindow
    {
        private List<ObjectConfiguration> _configs;
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
            _configs = ObjectConfiguration.GetAllConfigs();
        }

        private void OnGUI()
        {
            var newFindRequest = _searchField?.OnToolbarGUI(_findRequest);
        }
    }
}
