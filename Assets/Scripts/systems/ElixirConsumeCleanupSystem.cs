using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class ElixirConsumeCleanupSystem : ReactiveSystem<GameEntity> //, ISetPool, IEnsureComponents
    {
        // readonly Contexts contexts;

        public ElixirConsumeCleanupSystem(Contexts contexts) : base(contexts.game)
        {
            // this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Consume));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasConsume;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Destroy();
            }
        }
    }
}