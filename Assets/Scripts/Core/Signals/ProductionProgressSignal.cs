namespace PanteonStrategyGame.Core.Signals
{
    public class ProductionProgressSignal
    {
        public float RemainingTime { get; }
        public float TotalTime { get; }

        public ProductionProgressSignal(float remainingTime, float totalTime)
        {
            RemainingTime = remainingTime;
            TotalTime = totalTime;
        }
    }
}