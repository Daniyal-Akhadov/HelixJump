using CodeBase.Infrastructure.GameStates;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _gameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = new GameStateMachine(AllServices.Container, coroutineRunner);
        }

        public void StartGame()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}