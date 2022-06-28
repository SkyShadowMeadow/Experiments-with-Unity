using System;
using System.Collections.Generic;

namespace EventSystem.Events.Static
{
    public class GenericEvent<T> : EventBase
    {
        private Dictionary<string, List<Action<T>>> _keyActionEvents = new Dictionary<string, List<Action<T>>>();

        public void Add(string key, Action<T> action)
        {
            if (!_keyActionEvents.ContainsKey(key))
            {
                _keyActionEvents.Add(key, new List<Action<T>>());
            }

            _keyActionEvents[key].Add(action);
        }

        public void Remove(string key, Action<T> action)
        {
            if (_keyActionEvents.TryGetValue(key, out var actionList))
            {
                actionList.Remove(action);
            }
        }

        public void Invoke(string key, T value)
        {
            if (_keyActionEvents.TryGetValue(key, out var actionList))
            {
                foreach (var action in actionList)
                {
                    action.Invoke(value);
                }
            }
        }
    }
}
