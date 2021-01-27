using Entitas;

namespace Entitas_Reactive_UI.Example.systems
{
    public class TickUpdateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly Contexts contexts;

        public TickUpdateSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            contexts.game.ReplaceTick(0);
        }

        public void Execute()
        {
            if (!contexts.game.isPause)
            {
                contexts.game.ReplaceTick(contexts.game.tick.currentTick + 1);
            }
        }
    }
}