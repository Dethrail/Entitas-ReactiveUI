using UnityEngine;
using UnityEngine.UI;

namespace Entitas_Reactive_UI.Example
{
    public class TimeLabelBehaviour : MonoBehaviour, ITickListener
    {
        private Contexts contexts;

        private void Awake()
        {
            contexts = Contexts.sharedInstance;
            contexts.game.CreateEntity().AddTickListener(this);
        }

        public void TickChanged()
        {
            var tick = contexts.game.tick.currentTick;
            var sec = (tick / 60) % 60;
            var min = (tick / 3600);
            var secText = sec > 9 ? "" + sec : "0" + sec;
            var minText = min > 9 ? "" + min : "0" + min;

            GetComponent<Text>().text = minText + ":" + secText;
        }
    }
}