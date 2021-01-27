using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class ElixirConsumePersistSystem : ReactiveSystem<GameEntity>
    {
        readonly Contexts contexts;

        public ElixirConsumePersistSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Consume);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasConsume;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (contexts.game.isPause)
            {
                return;
            }

            var previousEntries = contexts.game.hasConsumptionHistory
                ? contexts.game.consumptionHistory.entires
                : new List<ConsumptionEntry>();
            foreach (var entity in entities)
            {
                previousEntries.Add(new ConsumptionEntry(contexts.game.tick.currentTick, entity.consume.amount));
            }

            contexts.game.ReplaceConsumptionHistory(previousEntries);
        }
    }
}