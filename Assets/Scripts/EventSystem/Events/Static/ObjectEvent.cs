using System;
using System.Collections.Generic;

namespace EventSystem.Events.Static
{
    public class ObjectEvent : EventBase
    {
        private Dictionary<string, List<Action<object[]>>> _keyActionEvents = new Dictionary<string, List<Action<object[]>>>();

        public void Add(string key, Action<object[]> action)
        {
            if (!_keyActionEvents.ContainsKey(key))
            {
                _keyActionEvents.Add(key, new List<Action<object[]>>());
            }

            _keyActionEvents[key].Add(action);
        }

        public void Remove(string key, Action<object[]> action)
        {
            if (_keyActionEvents.TryGetValue(key,out var actionList))
            {
                actionList.Remove(action);
            }
        }

        public void Invoke(string key, params object[] objects)
        {
            if (_keyActionEvents.TryGetValue(key, out var actionList))
            {
                foreach (var action in actionList)
                {
                    action?.Invoke(objects);
                }
            }
        }
    }
}
