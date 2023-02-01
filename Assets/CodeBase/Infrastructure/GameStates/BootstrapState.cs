using System;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, OnInitialSceneLoaded);
        }

        public void Exit()
        {
        }

        private void OnInitialSceneLoaded()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        private void RegisterServices()
        {
            IInputService inputService = RegisterInputService();
            _services.RegisterSingle<IInputService>(inputService);
        }

        private static IInputService RegisterInputService()
        {
            IInputService result = null;

            if (Application.isEditor == true)
                result = new PCInputService();
            else if (Application.isMobilePlatform == true)
                result = new MobileInputService();
            else
                throw new NullReferenceException("Not supported any other platform");

            return result;
        }
    }
}