using Entitas;

namespace Entitas_Reactive_UI.Example
{
    [Game]
    public class TickListenerComponent : IComponent
    {
        public ITickListener listener;
    }
}