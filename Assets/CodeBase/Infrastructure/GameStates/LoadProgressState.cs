using CodeBase.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.GameStates
{
    public class LoadProgressState : IState
    {
        private const int DefaultLevel = 1;
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _persistentProgressService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService persistentProgressService)
        {
            _gameStateMachine = gameStateMachine;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter()
        {
            _persistentProgressService.Progress = GetProgress();
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }

        private PlayerProgress GetProgress()
        {
            return _persistentProgressService.Progress ?? new PlayerProgress(DefaultLevel);
        }
    }
}