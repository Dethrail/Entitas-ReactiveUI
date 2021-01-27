using System;
using System.Collections.Generic;
using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class ElixirConsumeSystem : ReactiveSystem<GameEntity>
    {
        readonly Contexts contexts;

        public ElixirConsumeSystem(Contexts contexts) : base(contexts.game)
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
            foreach (var entity in entities)
            {
                if (entity.consume.amount > contexts.game.elixir.amount)
                {
                    UnityEngine.Debug.LogError("Consume more than produced. Should not happen");
                }

                var newAmount = Math.Max(0, contexts.game.elixir.amount - entity.consume.amount);
                contexts.game.ReplaceElixir(newAmount);
            }
        }
    }
}