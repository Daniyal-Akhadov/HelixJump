using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.GameStates
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;

        public GameLoopState(GameStateMachine gameStateMachine, IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.Allow();
        }

        public void Exit()
        {
        }
    }
}