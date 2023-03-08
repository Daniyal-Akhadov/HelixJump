using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.GameStates
{
    public class GameStateMachine : IService
    {
        private readonly Dictionary<Type, IExitState> _states;
        private IExitState _activeState;

        public GameStateMachine(AllServices services, ICoroutineRunner coroutineRunner)
        {
            SceneLoader sceneLoader = new SceneLoader(coroutineRunner);

            _states = new Dictionary<Type, IExitState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadProgressState)] = new LoadProgressState
                (
                    this,
                    services.Single<IPersistentProgressService>()
                ),
                [typeof(LoadLevelState)] = new LoadLevelState
                (
                    this,
                    services.Single<IGameFactory>(),
                    sceneLoader,
                    services.Single<IUIFactory>(),
                    services.Single<IInputService>()
                ),
                [typeof(GameLoopState)] = new GameLoopState(this, services.Single<IInputService>())
            };
        }

        public void Enter<TState>() where TState : IExitState
        {
            _activeState?.Exit();
            IState state = ChangeState<TState>();
            _activeState = state;
        }

        private IState ChangeState<TState>() where TState : IExitState
        {
            IState state = GetState<TState>();
            state.Enter();
            return state;
        }

        private IState GetState<TState>() where TState : IExitState =>
            (IState)_states[typeof(TState)];
    }
}