using System;

namespace PanteonStrategyGame.Core.StateMachine
{
    public class StateMachine
    {
        private IState _currentState;

        public Type CurrentStateType =>
            _currentState?.GetType();

        public void ChangeState(IState newState)
        {
            if (newState == null)
                return;

            if (_currentState == newState)
                return;

            _currentState?.Exit();

            _currentState = newState;

            _currentState.Enter();
        }

        public void Tick()
        {
            _currentState?.Tick();
        }
    }
}