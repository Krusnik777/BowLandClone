﻿namespace CodeBase.Infrastructure.StateMachine
{
    public interface ITickableState : IState
    {
        void Tick();
    }
}
