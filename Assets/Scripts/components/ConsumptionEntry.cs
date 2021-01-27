namespace Entitas_Reactive_UI.Example
{
    [Game]
    public class ConsumptionEntry
    {
        public ConsumptionEntry(long tick, int amount)
        {
            this.tick = tick;
            this.amount = amount;
        }

        public readonly long tick;
        public readonly int amount;
    }
}