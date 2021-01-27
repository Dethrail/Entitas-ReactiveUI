using Entitas;

namespace Entitas_Reactive_UI.Example
{
    [Game]
    public class PauseListenerComponent : IComponent
    {
        public IPauseListener listener;
    }
}