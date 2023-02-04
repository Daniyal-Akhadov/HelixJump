using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<int, TowerStaticData> _towers;

        public void LoadTowers()
        {
            _towers = UnityEngine.Resources.LoadAll<TowerStaticData>(AssetsPath.TowersStaticDataPath)
                .ToDictionary(tower => tower.LevelId);
        }

        public TowerStaticData ForTower(int levelId)
        {
            return _towers[levelId];
        }
    }

    public interface IStaticDataService : IService
    {
        void LoadTowers();
        TowerStaticData ForTower(int levelId);
    }

    public static class AssetsPath
    {
        public const string TowersStaticDataPath = "StaticData/Towers";
    }
}