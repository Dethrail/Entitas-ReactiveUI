using System;
using UnityEngine;
using Entitas;
using Entitas_Reactive_UI.Example.systems;

public class GameApplication : MonoBehaviour
{
    private Systems systems;
    private Contexts contexts;

    protected void Awake()
    {
        Application.targetFrameRate = 60;
        contexts = Contexts.sharedInstance;
        contexts.game.Reset();
        systems = new RootSystems(contexts);
    }

    public void Start()
    {
        systems.ActivateReactiveSystems();
        systems.Initialize();
    }

    protected void Update()
    {
        if (systems != null)
        {
            systems.Execute();
            systems.Cleanup();
        }
    }
}