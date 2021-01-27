using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Entitas_Reactive_UI.Example
{
    [Unique]
    public class JumpInTimeComponent : IComponent
    {
        public long targetTick;
    }
}