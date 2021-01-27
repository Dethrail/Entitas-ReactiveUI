using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Entitas_Reactive_UI.Example
{
    [Game][Unique]
    public class TickComponent : IComponent
    {
        public long currentTick;
    }
}