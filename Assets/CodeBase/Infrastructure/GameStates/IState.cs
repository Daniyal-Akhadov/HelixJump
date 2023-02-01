namespace CodeBase.Infrastructure.GameStates
{
    public interface IState : IExitState
    {
        void Enter();
    }
}