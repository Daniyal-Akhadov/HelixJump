using System;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
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
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<GameStateMachine>(_gameStateMachine);
            IInputService inputService = RegisterInputService();
            _services.RegisterSingle<IInputService>(inputService);
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IStaticDataService>(RegisterStaticData());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>
            (
                new GameFactory
                (
                    _services.Single<IStaticDataService>(),
                    _services.Single<IPersistentProgressService>(),
                    _services.Single<IAssetProvider>(),
                    _services.Single<IInputService>()
                )
            );

            _services.RegisterSingle<IUIFactory>
            (
                new UIFactory
                (
                    _services.Single<IAssetProvider>(),
                    _services.Single<IStaticDataService>()
                )
            );

            _services.RegisterSingle<IWindowService>
            (
                new WindowService(_services.Single<IUIFactory>())
            );
        }

        private static IStaticDataService RegisterStaticData()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadStaticData();
            return staticDataService;
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