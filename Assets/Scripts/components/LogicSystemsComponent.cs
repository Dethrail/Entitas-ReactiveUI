using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Entitas_Reactive_UI.Example
{
    [Game][Unique]
    public class LogicSystemsComponent : IComponent
    {
        public Systems systems;
    }
}