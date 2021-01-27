using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class ReplaySystem : ReactiveSystem<GameEntity> //, ISetPool, IEnsureComponents
    {
        readonly GameContext gameContext;

        public ReplaySystem(Contexts contexts) : base(contexts.game)
        {
            gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // return Matcher.JumpInTime.OnEntityAdded();
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.JumpInTime));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasJumpInTime;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var logicSystems = gameContext.logicSystems.systems;
            logicSystems.Initialize();
            var actions = gameContext.hasConsumptionHistory
                ? gameContext.consumptionHistory.entires
                : new List<ConsumptionEntry>();
            var actionIndex = 0;
            for (int tick = 0; tick <= gameContext.jumpInTime.targetTick; tick++)
            {
                gameContext.ReplaceTick(tick);
                if (actions.Count > actionIndex && actions[actionIndex].tick == tick)
                {
                    gameContext.CreateEntity().AddConsume(actions[actionIndex].amount);
                    actionIndex++;
                }

                logicSystems.Execute();
            }
        }
    }
}