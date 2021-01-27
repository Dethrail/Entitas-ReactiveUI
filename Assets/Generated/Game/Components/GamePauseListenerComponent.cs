//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Entitas_Reactive_UI.Example.PauseListenerComponent pauseListener { get { return (Entitas_Reactive_UI.Example.PauseListenerComponent)GetComponent(GameComponentsLookup.PauseListener); } }
    public bool hasPauseListener { get { return HasComponent(GameComponentsLookup.PauseListener); } }

    public void AddPauseListener(Entitas_Reactive_UI.Example.IPauseListener newListener) {
        var index = GameComponentsLookup.PauseListener;
        var component = (Entitas_Reactive_UI.Example.PauseListenerComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.PauseListenerComponent));
        component.listener = newListener;
        AddComponent(index, component);
    }

    public void ReplacePauseListener(Entitas_Reactive_UI.Example.IPauseListener newListener) {
        var index = GameComponentsLookup.PauseListener;
        var component = (Entitas_Reactive_UI.Example.PauseListenerComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.PauseListenerComponent));
        component.listener = newListener;
        ReplaceComponent(index, component);
    }

    public void RemovePauseListener() {
        RemoveComponent(GameComponentsLookup.PauseListener);
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

    static Entitas.IMatcher<GameEntity> _matcherPauseListener;

    public static Entitas.IMatcher<GameEntity> PauseListener {
        get {
            if (_matcherPauseListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PauseListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPauseListener = matcher;
            }

            return _matcherPauseListener;
        }
    }
}
