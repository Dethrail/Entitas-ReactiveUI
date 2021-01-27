using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class NotifyPauseListenersSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> listeners;

        public NotifyPauseListenersSystem(Contexts contexts) : base(contexts.game)
        {
            listeners = contexts.game.GetGroup(GameMatcher.PauseListener);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Pause));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPause;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in listeners.GetEntities())
            {
                entity.pauseListener.listener.PauseStateChanged();
            }
        }
    }
}