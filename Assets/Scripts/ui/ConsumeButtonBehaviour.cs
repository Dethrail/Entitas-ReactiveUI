using System;
using UnityEngine;
using UnityEngine.UI;

namespace Entitas_Reactive_UI.Example
{
    public class ConsumeButtonBehaviour : MonoBehaviour, IPauseListener, IElixirListener
    {
        private Contexts contexts;

        public Text label;
        public RectTransform progressBox;
        public int consumptionAmount;

        float maxHeight;

        private void Awake()
        {
            contexts = Contexts.sharedInstance;
            contexts.game.CreateEntity().AddPauseListener(this);
            contexts.game.CreateEntity().AddElixirListener(this);

            maxHeight = progressBox.rect.height;
            label.text = consumptionAmount.ToString();
        }

        public void PauseStateChanged()
        {
            GetComponent<Button>().enabled = !contexts.game.isPause;
        }

        public void ElixirAmountChanged()
        {
            var ratio = 1 - Mathf.Min(1f, (contexts.game.elixir.amount / (float) consumptionAmount));
            progressBox.sizeDelta = new Vector2(progressBox.rect.width, maxHeight * ratio);
            GetComponent<Button>().enabled = (Math.Abs(ratio - 0) < Mathf.Epsilon);
        }

        public void ButtonPressed()
        {
            if (contexts.game.isPause) return;
            contexts.game.CreateEntity().AddConsume(consumptionAmount);
        }
    }
}