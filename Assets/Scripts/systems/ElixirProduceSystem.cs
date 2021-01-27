using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Entitas_Reactive_UI.Example.systems
{
    public class ElixirProduceSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        readonly Contexts contexts;
        int count = 0;

        // This should be inside of a config file
        public const float ElixirCapacity = 10f;
        const int ProductionFrequency = 3;
        const float ProductionStep = 0.01f;

        public ElixirProduceSystem(Contexts contexts) : base(contexts.game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Tick);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTick;
        }

        public void Initialize()
        {
            contexts.game.ReplaceElixir(0);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if (count == 0)
            {
                contexts.game.elixir.amount = Math.Min(ElixirCapacity, contexts.game.elixir.amount + ProductionStep);
            }

            count = ((count + 1) % ProductionFrequency);
        }
    }
}