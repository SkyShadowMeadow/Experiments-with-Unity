
namespace EventSystem.Dispose
{
    public static class DisposeContainerExtension
    {
        public static DisposeContainer AddTo(this DisposeContainer disposeAction, EventDisposal disposeActions)
        {
            disposeActions.Add(disposeAction);
            return disposeAction;
        }
    }
}
