//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity jumpInTimeEntity { get { return GetGroup(GameMatcher.JumpInTime).GetSingleEntity(); } }
    public Entitas_Reactive_UI.Example.JumpInTimeComponent jumpInTime { get { return jumpInTimeEntity.jumpInTime; } }
    public bool hasJumpInTime { get { return jumpInTimeEntity != null; } }

    public GameEntity SetJumpInTime(long newTargetTick) {
        if (hasJumpInTime) {
            throw new Entitas.EntitasException("Could not set JumpInTime!\n" + this + " already has an entity with Entitas_Reactive_UI.Example.JumpInTimeComponent!",
                "You should check if the context already has a jumpInTimeEntity before setting it or use context.ReplaceJumpInTime().");
        }
        var entity = CreateEntity();
        entity.AddJumpInTime(newTargetTick);
        return entity;
    }

    public void ReplaceJumpInTime(long newTargetTick) {
        var entity = jumpInTimeEntity;
        if (entity == null) {
            entity = SetJumpInTime(newTargetTick);
        } else {
            entity.ReplaceJumpInTime(newTargetTick);
        }
    }

    public void RemoveJumpInTime() {
        jumpInTimeEntity.Destroy();
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

    public Entitas_Reactive_UI.Example.JumpInTimeComponent jumpInTime { get { return (Entitas_Reactive_UI.Example.JumpInTimeComponent)GetComponent(GameComponentsLookup.JumpInTime); } }
    public bool hasJumpInTime { get { return HasComponent(GameComponentsLookup.JumpInTime); } }

    public void AddJumpInTime(long newTargetTick) {
        var index = GameComponentsLookup.JumpInTime;
        var component = (Entitas_Reactive_UI.Example.JumpInTimeComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.JumpInTimeComponent));
        component.targetTick = newTargetTick;
        AddComponent(index, component);
    }

    public void ReplaceJumpInTime(long newTargetTick) {
        var index = GameComponentsLookup.JumpInTime;
        var component = (Entitas_Reactive_UI.Example.JumpInTimeComponent)CreateComponent(index, typeof(Entitas_Reactive_UI.Example.JumpInTimeComponent));
        component.targetTick = newTargetTick;
        ReplaceComponent(index, component);
    }

    public void RemoveJumpInTime() {
        RemoveComponent(GameComponentsLookup.JumpInTime);
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

    static Entitas.IMatcher<GameEntity> _matcherJumpInTime;

    public static Entitas.IMatcher<GameEntity> JumpInTime {
        get {
            if (_matcherJumpInTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpInTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpInTime = matcher;
            }

            return _matcherJumpInTime;
        }
    }
}
