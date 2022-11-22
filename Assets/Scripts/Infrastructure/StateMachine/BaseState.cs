namespace TDS.Infrastructure.StateMachine
{
    public abstract class BaseState : IState
    {
        protected IGameStateMachine StateMachine { get; }

        protected BaseState(IGameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        public abstract void Enter();
        public abstract void Exit();
    }
}