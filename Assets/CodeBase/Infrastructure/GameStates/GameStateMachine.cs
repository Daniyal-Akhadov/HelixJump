using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitState> _states;
        private IExitState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
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
                    sceneLoader
                ),
                [typeof(GameLoopState)] = new GameLoopState()
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