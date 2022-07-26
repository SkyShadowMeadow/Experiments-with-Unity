using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Configuration
{
    public class ObjectConfiguration : ScriptableObject
    {
        private static Dictionary<Type, ObjectConfiguration> _cash;

        public T GetConfig<T>() where T : ObjectConfiguration
        {
            return GetConfig(typeof(T)) as T;
        }

        public static ObjectConfiguration GetConfig(Type type)
        {
            _cash ??= new Dictionary<Type, ObjectConfiguration>();
            if (_cash.ContainsKey(type))
            {
                return _cash[type];
            }

            var value = Resources.Load($"/Configs/{type.Name}");
            
#if UNITY_EDITOR
            if (value is null)
            {
                Debug.Log($"Settings {type.Name} are not found");
                var asset = CreateInstance(type);
                asset.name = type.Name;
                AssetDatabase.CreateAsset(asset, $"/Assets/Resources/Configs/{type.Name}.asset");
                value = asset;
            }
#endif
            var castedValue = value as ObjectConfiguration;
            _cash.Add(type, castedValue);
            return castedValue ;
        }
    }
}
