using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<int, TowerStaticData> _towers;
        private Dictionary<WindowId, WindowConfig> _windows;

        public void LoadStaticData()
        {
            _towers = UnityEngine.Resources.LoadAll<TowerStaticData>(AssetsPath.TowersStaticDataPath)
                .ToDictionary(tower => tower.LevelId);

            _windows = UnityEngine.Resources.Load<WindowStaticData>(AssetsPath.WindowsStaticDataPath)
                .WindowConfigs
                .ToDictionary(config => config.WindowId);
        }

        public TowerStaticData ForTower(int levelId)
        {
            return _towers[levelId];
        }

        public WindowConfig ForWindow(WindowId windowId)
        {
            return _windows[windowId];
        }
    }

    public static class AssetsPath
    {
        public const string TowersStaticDataPath = "StaticData/Towers";
        public const string WindowsStaticDataPath = "StaticData/UI/Windows";
    }
}