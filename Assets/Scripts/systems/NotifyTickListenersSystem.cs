using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class NotifyTickListenersSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> listeners;
        private readonly Contexts contexts;

        public NotifyTickListenersSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
            listeners = contexts.game.GetGroup(GameMatcher.TickListener);
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
                entity.tickListener.listener.TickChanged();
            }
        }
    }
}