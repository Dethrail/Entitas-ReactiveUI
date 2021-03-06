//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity elixirEntity { get { return GetGroup(GameMatcher.Elixir).GetSingleEntity(); } }
    public Entitas_Reactive_UI.Example.ElixirComponent elixir { get { return elixirEntity.elixir; } }
    public bool hasElixir { get { return elixirEntity != null; } }

    public GameEntity SetElixir(float newAmount) {
        if (hasElixir) {
            throw new Entitas.EntitasException("Could not set Elixir!\n" + this + " already has an entity with Entitas_Reactive_UI.Example.ElixirComponent!",
                "You should check if the context already has a elixirEntity before setting it or use context.ReplaceElixir().");
        }
        var entity = CreateEntity();
        entity.AddElixir(newAmount);
        return entity;
    }

    public void ReplaceElixir(float newAmount) {
        var entity = elixirEntity;
        if (entity == null) {
            entity = SetElixir(newAmount);
        } else {
            entity.ReplaceElixir(newAmount);
        }
    }

    public void RemoveElixir() {
        elixirEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Entitas_Reactive_UI.Example.ElixirComponent elixir { get { return (Entitas_Reactive_UI.Example.ElixirComponent)GetComponent(GameComponentsLookup.Elixir); } }
    public bool hasElixir { get { return HasComponent(GameComponentsLookup.Elixir); } }

    public void AddElixir(float newAmount) {
        var index = GameComponentsLookup.Elixir;
        var component = (Entitas_Reactive_UI.Example.ElixirComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.ElixirComponent));
        component.amount = newAmount;
        AddComponent(index, component);
    }

    public void ReplaceElixir(float newAmount) {
        var index = GameComponentsLookup.Elixir;
        var component = (Entitas_Reactive_UI.Example.ElixirComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.ElixirComponent));
        component.amount = newAmount;
        ReplaceComponent(index, component);
    }

    public void RemoveElixir() {
        RemoveComponent(GameComponentsLookup.Elixir);
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

    static Entitas.IMatcher<GameEntity> _matcherElixir;

    public static Entitas.IMatcher<GameEntity> Elixir {
        get {
            if (_matcherElixir == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Elixir);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherElixir = matcher;
            }

            return _matcherElixir;
        }
    }
}
