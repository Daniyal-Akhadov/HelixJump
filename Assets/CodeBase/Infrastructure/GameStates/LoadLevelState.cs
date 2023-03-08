using CodeBase.Infrastructure.Services;
using CodeBase.Logic.Camera;
using CodeBase.Logic.Platform;
using CodeBase.Logic.Tower;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private const string Main = "Main";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IInputService _inputService;

        public LoadLevelState
        (
            GameStateMachine gameStateMachine,
            IGameFactory gameFactory,
            SceneLoader sceneLoader,
            IUIFactory uiFactory,
            IInputService inputService
        )
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.Block();
            _sceneLoader.Load(name: Main, OnSceneLoaded);
        }

        public void Exit()
        {
        }

        private void OnSceneLoaded()
        {
            InitUI();
            InitialGameWorld();
        }

        private void InitUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateStartWindow();
        }

        private void InitialGameWorld()
        {
            GameObject tower = _gameFactory.CreateTower();
            Vector3 initialBallPosition = tower.GetComponentInChildren<StartPlatform>().SpawnPoint.position;
            GameObject ball = _gameFactory.CreateBall(initialBallPosition);
            SetupCamera(ball, tower.GetComponentInChildren<Beam>().gameObject);
            _gameFactory.CreateHUD();
        }

        private static void SetupCamera(GameObject ball, GameObject beam)
        {
            CameraFollower activeVirtualCamera = Camera.main.GetComponent<CameraFollower>();
            activeVirtualCamera.SetTarget(ball.transform, beam.transform);
        }
    }
}