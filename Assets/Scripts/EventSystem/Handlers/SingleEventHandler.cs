using System;
using EventSystem.Dispose;
using EventSystem.Events.Static;
using UnityEngine;

namespace EventSystem.Handlers
{
    public static class SingleEventHandler
    {
        private static SingleEvent _singleEvents;

        public static DisposeContainer Add(string key, Action action)
        {
            if (_singleEvents is null)
            {
                _singleEvents = new SingleEvent();
            }
            
            _singleEvents.Add(key, action);
            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove(string key, Action action) =>_singleEvents?.Remove(key, action);
        
        public static void Invoke(string key) =>_singleEvents?.Invoke(key);
    }
}
