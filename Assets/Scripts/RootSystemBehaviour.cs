using Entitas;
using Entitas_Reactive_UI.Example.systems;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        var logicSystems = CreateLogicSystems(contexts);

        Add(logicSystems);
        Add(new ReplaySystem(contexts));
        Add(new NotifyTickListenersSystem(contexts));
        Add(new NotifyElixirListenersSystem(contexts));
        Add(new NotifyPauseListenersSystem(contexts));
        Add(new CleanupConsumptionHistorySystem(contexts));
    }

    private Systems CreateLogicSystems(Contexts contexts)
    {
        var gameContext = Contexts.sharedInstance.game;
        if (!gameContext.hasLogicSystems)
        {
            gameContext.SetLogicSystems(new Systems()
                .Add(new TickUpdateSystem(contexts))
                .Add(new ElixirProduceSystem(contexts))
                .Add(new ElixirConsumeSystem(contexts))
                .Add(new ElixirConsumePersistSystem(contexts))
                .Add(new ElixirConsumeCleanupSystem(contexts)));
        }

        return gameContext.logicSystems.systems;
    }
}