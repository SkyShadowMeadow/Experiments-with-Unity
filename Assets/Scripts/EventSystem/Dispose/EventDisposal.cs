using System.Collections.Generic;

namespace EventSystem.Dispose
{
    public class EventDisposal
    {
        private List<DisposeContainer> _disposeActions = new List<DisposeContainer>();

        public void Add(DisposeContainer disposeAction)
        {
            _disposeActions.Add(disposeAction);
        }

        public void Remove()
        {
            while (_disposeActions.Count > 0)
            {
                DisposeContainer disposeAction = _disposeActions[0];
                _disposeActions.Remove(disposeAction);
                disposeAction.Invoke();
            }
        }
    }
}
