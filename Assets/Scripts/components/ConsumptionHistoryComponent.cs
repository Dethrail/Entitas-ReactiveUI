using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Entitas_Reactive_UI.Example
{
    [Game][Unique]
    public class ConsumptionHistoryComponent : IComponent
    {
        public List<ConsumptionEntry> entires;
    }
}