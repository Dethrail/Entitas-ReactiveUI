using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class NotifyElixirListenersSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> listeners;

        public NotifyElixirListenersSystem(Contexts contexts) : base(contexts.game)
        {
            listeners = contexts.game.GetGroup(GameMatcher.ElixirListener);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Tick));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in listeners.GetEntities())
            {
                entity.elixirListener.listener.ElixirAmountChanged();
            }
        }
    }
}