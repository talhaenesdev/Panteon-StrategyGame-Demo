using PanteonStrategyGame.Units.Data;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IProductionQueue
    {
        void Enqueue(UnitData unit);

        void Tick(float deltaTime);

        bool IsProducing { get; }
    }
}