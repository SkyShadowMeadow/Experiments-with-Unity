using System;
using EventSystem.Dispose;
using EventSystem.Handlers;
using UnityEngine;

namespace EventSystem
{
    public static class EventManager
    {
        public static DisposeContainer Add(string key, Action action) => SingleEventHandler.Add(key, action);
        public static DisposeContainer Add(Enum key, Action action) => SingleEventHandler.Add(key.ToString(), action);
        
        public static DisposeContainer Add<T>(string key, Action<T> action) => GenericEventHandler.Add(key, action);
        public static DisposeContainer Add<T>(Enum key, Action<T> action) => GenericEventHandler.Add(key.ToString(), action);
        
        public static DisposeContainer Add(string key, Action<object[]> action) => ObjectEventHandler.Add(key, action);
        public static DisposeContainer Add(Enum key, Action<object[]> action) => ObjectEventHandler.Add(key.ToString(), action);
        
        
        public static void Remove(string key, Action action) => SingleEventHandler.Remove(key, action);
        public static void Remove(Enum key, Action action) => SingleEventHandler.Remove(key.ToString(), action);
        
        public static void Remove<T>(string key, Action<T> action) => GenericEventHandler.Remove(key, action);
        public static void Remove<T>(Enum key, Action<T> action) => GenericEventHandler.Remove(key.ToString(), action);
        
        public static void Remove(string key, Action<object[]> action) => ObjectEventHandler.Remove(key, action);
        public static void Remove(Enum key, Action<object[]> action) => ObjectEventHandler.Remove(key.ToString(), action);
        
        
        public static void Invoke(string key) => SingleEventHandler.Invoke(key);
        public static void Invoke(Enum key) => SingleEventHandler.Invoke(key.ToString());
        
        public static void Invoke<T>(string key, T arg) => GenericEventHandler.Invoke(key, arg);
        public static void Invoke<T>(Enum key, T arg) => GenericEventHandler.Invoke(key.ToString(), arg);
        
        public static void Invoke(string key, params object[] args) => ObjectEventHandler.Invoke(key, args);
        public static void Invoke(Enum key, params object[] args) => ObjectEventHandler.Invoke(key.ToString(), args);
    }
}
