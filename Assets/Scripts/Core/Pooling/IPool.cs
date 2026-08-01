namespace PanteonStrategyGame.Core.Pooling
{
    public interface IPool<T>
    {
        T Get();
        void Release(T item);
    }
}