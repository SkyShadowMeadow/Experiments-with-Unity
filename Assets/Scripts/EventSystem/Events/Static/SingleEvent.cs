using System;
using System.Collections.Generic;

namespace EventSystem.Events.Static
{
    public class SingleEvent : EventBase
    {
        private Dictionary<string, List<Action>> _keyActionEvents = new Dictionary<string, List<Action>>();

        public void Add(string key, Action action)
        {
            if (!_keyActionEvents.ContainsKey(key))
            {
                _keyActionEvents.Add(key, new List<Action>());
            }

            _keyActionEvents[key].Add(action);
        }

        public void Remove(string key, Action action)
        {
            if (_keyActionEvents.TryGetValue(key,out var actionList))
            {
                actionList.Remove(action);
            }
        }

        public void Invoke(string key)
        {
            if (_keyActionEvents.TryGetValue(key, out var actionList))
            {
                foreach (var action in actionList)
                {
                    action?.Invoke();
                }
            }
        }
    }
}
