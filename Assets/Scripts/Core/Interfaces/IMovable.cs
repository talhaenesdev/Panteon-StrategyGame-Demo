using UnityEngine;

namespace PanteonStrategyGame.Core.Interfaces
{
    public interface IMovable
    {
        void MoveTo(Vector3 destination);
        void Stop();
    }
}