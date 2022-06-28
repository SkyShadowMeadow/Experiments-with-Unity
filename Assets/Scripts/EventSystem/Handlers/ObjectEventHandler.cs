using System;
using EventSystem.Dispose;
using EventSystem.Events.Static;

namespace EventSystem.Handlers
{
    public static class ObjectEventHandler
    {
        private static ObjectEvent _objectEvents;

        public static DisposeContainer Add(string key, Action<object[]> action)
        {
            if (_objectEvents is null)
            {
                _objectEvents = new ObjectEvent();
            }
            
            _objectEvents.Add(key, action);
            return new DisposeContainer(() => Remove(key, action));
        }

        public static void Remove(string key, Action<object[]> action) =>_objectEvents?.Remove(key, action);
        

        public static void Invoke(string key, params object[] arg) =>_objectEvents?.Invoke(key, arg);
    }
}
