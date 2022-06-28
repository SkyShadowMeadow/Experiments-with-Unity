using System;
using System.Collections.Generic;
using EventSystem.Dispose;
using EventSystem.Events.Static;
using EventBase = EventSystem.Events.EventBase;

namespace EventSystem.Handlers
{
    public static class GenericEventHandler
    {
        private static Dictionary<Type, EventBase> _genericEvents = new Dictionary<Type, EventBase>();

        public static DisposeContainer Add<T>(string key, Action<T> action)
        {
            var type = typeof(T);
            GenericEvent<T> genericEvent = null;
            
            if (!_genericEvents.ContainsKey(type))
            {
                genericEvent = new GenericEvent<T>();
                _genericEvents.Add(type, genericEvent);
            }
            else
            {
                genericEvent = _genericEvents[type] as GenericEvent<T>;
            }
            
            genericEvent?.Add(key, action);
            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove<T>(string key, Action<T> action)
        {
            if (_genericEvents.TryGetValue(typeof(T), out var genericEvents))
            {
                var events = genericEvents as GenericEvent<T>;
                events?.Remove(key, action);
            }
        }

        public static void Invoke<T>(string key, T arg)
        {
            if (_genericEvents.TryGetValue(typeof(T), out var genericEvents))
            {
                var events = genericEvents as GenericEvent<T>;
                events?.Invoke(key, arg);
            }
        }
    }
}
