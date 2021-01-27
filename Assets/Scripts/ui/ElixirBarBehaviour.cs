using Entitas_Reactive_UI.Example;
using Entitas_Reactive_UI.Example.systems;
using UnityEngine;

namespace IdleProject
{
    public class ElixirBarBehaviour : MonoBehaviour, IElixirListener
    {
        void Start()
        {
            Contexts.sharedInstance.game.CreateEntity().AddElixirListener(this);
        }

        public void ElixirAmountChanged()
        {
            var ratio = Contexts.sharedInstance.game.elixir.amount / ElixirProduceSystem.ElixirCapacity;
            GetComponent<RectTransform>().localScale = new Vector3(ratio, 1f, 1f);
        }
    }
}