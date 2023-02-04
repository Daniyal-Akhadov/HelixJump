using CodeBase.Logic.Camera;
using CodeBase.Logic.Platform;
using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private const string Main = "Main";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState
        (
            GameStateMachine gameStateMachine,
            IGameFactory gameFactory,
            SceneLoader sceneLoader
        )
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(name: Main, OnSceneLoaded);
        }

        public void Exit()
        {
        }

        private void OnSceneLoaded()
        {
            _gameStateMachine.Enter<GameLoopState>();
            InitialGameWorld();
        }

        private void InitialGameWorld()
        {
            GameObject tower = _gameFactory.CreateTower();
            Vector3 initialBallPosition = tower.GetComponentInChildren<StartPlatform>().SpawnPoint.position;
            GameObject ball = _gameFactory.CreateBall(initialBallPosition);
            SetupCamera(ball, tower.GetComponentInChildren<Beam>().transform);
        }

        private static void SetupCamera(GameObject ball, Transform beam)
        {
            Camera.main.GetComponent<CameraFollower>().SetTarget(ball, beam);
        }
    }
}