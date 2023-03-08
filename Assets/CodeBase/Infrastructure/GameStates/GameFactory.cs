using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic.Player;
using CodeBase.Logic.Tower;
using CodeBase.StaticData;
using CodeBase.UI.Elements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.GameStates
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;
        private GameObject _ball;
        private TowerBuilder _towerBuilder;


        public GameFactory
        (
            IStaticDataService staticDataService,
            IPersistentProgressService persistentProgressService,
            IAssetProvider assetProvider,
            IInputService inputService
        )
        {
            _staticDataService = staticDataService;
            _persistentProgressService = persistentProgressService;
            _assetProvider = assetProvider;
            _inputService = inputService;
        }

        public GameObject CreateTower()
        {
            int levelId = _persistentProgressService.Progress.Level;
            TowerStaticData towerStaticData = _staticDataService.ForTower(levelId);
            _towerBuilder = Object.Instantiate(towerStaticData.Prefab);
            _towerBuilder.MaxRotationY = towerStaticData.MaxRotationY;
            _towerBuilder.MinRotationY = towerStaticData.MinRotationY;
            _towerBuilder.AdditionalBeamHeight = towerStaticData.AdditionalBeamHeight;
            _towerBuilder.LevelCount = towerStaticData.LevelCount;
            _towerBuilder.LevelHeight = towerStaticData.LevelHeight;
            _towerBuilder.Build();
            return _towerBuilder.gameObject;
        }

        public GameObject CreateBall(Vector3 initialBallPosition)
        {
            _ball = _assetProvider.Instantiate(AssetsPath.Ball, initialBallPosition);
            _ball.GetComponent<BallDeath>().Construct(_inputService);
            return _ball;
        }

        public void CreateHUD()
        {
            GameObject hud = _assetProvider.Instantiate(AssetsPath.HUD);
            hud.GetComponent<ActorUI>().Construct
            (
                _ball.GetComponent<BallPlatformBreaker>(),
                _towerBuilder
            );
        }
    }
}