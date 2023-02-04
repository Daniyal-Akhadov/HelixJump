using CodeBase.Infrastructure.Services;
using CodeBase.Logic.Tower;
using CodeBase.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.GameStates
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IAssetProvider _assetProvider;

        public GameFactory
        (
            IStaticDataService staticDataService,
            IPersistentProgressService persistentProgressService,
            IAssetProvider assetProvider
        )
        {
            _staticDataService = staticDataService;
            _persistentProgressService = persistentProgressService;
            _assetProvider = assetProvider;
        }

        public GameObject CreateTower()
        {
            int levelId = _persistentProgressService.Progress.Level;
            TowerStaticData towerStaticData = _staticDataService.ForTower(levelId);
            TowerBuilder towerBuilder = Object.Instantiate(towerStaticData.Prefab);
            towerBuilder.MaxRotationY = towerStaticData.MaxRotationY;
            towerBuilder.MinRotationY = towerStaticData.MinRotationY;
            towerBuilder.AdditionalBeamHeight = towerStaticData.AdditionalBeamHeight;
            towerBuilder.LevelCount = towerStaticData.LevelCount;
            towerBuilder.LevelHeight = towerStaticData.LevelHeight;
            towerBuilder.Build();
            return towerBuilder.gameObject;
        }

        public GameObject CreateBall(Vector3 initialBallPosition)
        {
            return _assetProvider.Instantiate(AssetsPath.Ball, initialBallPosition);
        }
    }
}