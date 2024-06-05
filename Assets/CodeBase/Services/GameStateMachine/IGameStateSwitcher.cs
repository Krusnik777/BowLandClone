using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Infrastructure.StateMachine;


namespace CodeBase.Services.GameStateMachine
{
    public interface IGameStateSwitcher: IService
    {
        object CurrentState { get; }

        void AddState<TState>(TState state) where TState : class, IState;
        void RemoveState<TState>() where TState : class, IState;
        void Enter<TState>() where TState : class, IState;
        void Exit<TState>() where TState : class, IState;
        void UpdateTick();
    }
}
