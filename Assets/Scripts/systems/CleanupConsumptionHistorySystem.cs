using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class CleanupConsumptionHistorySystem : ReactiveSystem<GameEntity>
    {
        readonly Contexts contexts;

        public CleanupConsumptionHistorySystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Pause);
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isPause;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var actions = contexts.game.hasConsumptionHistory
                ? contexts.game.consumptionHistory.entires
                : new List<ConsumptionEntry>();
            int count = 0;
            for (int index = actions.Count - 1; index >= 0; index--)
            {
                if (actions[index].tick > contexts.game.tick.currentTick)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            actions.RemoveRange(actions.Count - count, count);
        }
    }
}