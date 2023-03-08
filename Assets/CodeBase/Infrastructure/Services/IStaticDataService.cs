using CodeBase.StaticData;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadStaticData();
        TowerStaticData ForTower(int levelId);
        WindowConfig ForWindow(WindowId windowId);
    }
}