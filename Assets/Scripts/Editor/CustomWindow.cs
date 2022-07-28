using System;
using System.Collections.Generic;
using System.Reflection;
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
        private string[] _configsNames;
        private bool[] _isFoldout;
        private Vector2 _scrollPos;
        
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
            _isFoldout = new bool[_configs.Count];
            
            _configsNames = new string[_configs.Count];
            
            for (var i = 0; i < _configs.Count; i++)
            {
                _configsNames[i] = GetConfigName(_configs[i]);
            }
        }

        private void OnGUI()
        {
            var newFindRequest = _searchField?.OnToolbarGUI(_findRequest);
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, false, true);
            
            for (var i = 0; i < _configs.Count; i++)
            {
                var objectConfig = _configs[i];
                var serializedObject = new SerializedObject(objectConfig);

                _isFoldout[i] = EditorGUILayout.Foldout(_isFoldout[i], GetConfigName(objectConfig));

                if (_isFoldout[i])
                    DrawSerializedObject(serializedObject);
            }
            
            EditorGUILayout.EndScrollView();
        }
        
        
        private string GetConfigName(ObjectConfiguration config)
        {
            return config.GetType().Name;
        }
        
        private void DrawSerializedObject(SerializedObject serializedObject)
        {
            if (serializedObject == null)
            {
                EditorGUILayout.HelpBox("Target SerializedObject is null!", MessageType.Warning);
                return;
            }

            // display serializedProperty with selected mode
            Type type = typeof(SerializedObject);
            PropertyInfo infor = type.GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
            if (infor != null)
            {
                infor.SetValue(serializedObject, InspectorMode.Normal, null);
            }

            var iterator = serializedObject.GetIterator();

            //first call draw target script
            iterator.NextVisible(true);


            while (iterator.NextVisible(false))
            {
                //  enterChildren = false;
                EditorGUILayout.PropertyField(iterator, true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
