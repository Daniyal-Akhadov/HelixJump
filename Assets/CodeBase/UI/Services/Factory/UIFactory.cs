using CodeBase.Infrastructure.GameStates;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/[UI]";

        private readonly IAssetProvider _assetsProvider;
        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;

        public UIFactory(IAssetProvider assetsProvider, IStaticDataService staticData)
        {
            _assetsProvider = assetsProvider;
            _staticData = staticData;
        }

        public void CreateUIRoot() =>
            _uiRoot = _assetsProvider.Instantiate(UIRootPath).transform;

        public void CreateStartWindow()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Start);
            Object.Instantiate(config.Prefab, _uiRoot);
        }
    }
}