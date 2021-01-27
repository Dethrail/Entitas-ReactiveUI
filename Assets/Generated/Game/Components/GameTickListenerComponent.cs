//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Entitas_Reactive_UI.Example.TickListenerComponent tickListener { get { return (Entitas_Reactive_UI.Example.TickListenerComponent)GetComponent(GameComponentsLookup.TickListener); } }
    public bool hasTickListener { get { return HasComponent(GameComponentsLookup.TickListener); } }

    public void AddTickListener(Entitas_Reactive_UI.Example.ITickListener newListener) {
        var index = GameComponentsLookup.TickListener;
        var component = (Entitas_Reactive_UI.Example.TickListenerComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.TickListenerComponent));
        component.listener = newListener;
        AddComponent(index, component);
    }

    public void ReplaceTickListener(Entitas_Reactive_UI.Example.ITickListener newListener) {
        var index = GameComponentsLookup.TickListener;
        var component = (Entitas_Reactive_UI.Example.TickListenerComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.TickListenerComponent));
        component.listener = newListener;
        ReplaceComponent(index, component);
    }

    public void RemoveTickListener() {
        RemoveComponent(GameComponentsLookup.TickListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTickListener;

    public static Entitas.IMatcher<GameEntity> TickListener {
        get {
            if (_matcherTickListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TickListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTickListener = matcher;
            }

            return _matcherTickListener;
        }
    }
}
