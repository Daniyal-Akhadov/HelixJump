using CodeBase.Infrastructure.GameStates;
using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Window
{
    public class StartWindow : BaseWindow
    {
        protected override void OnButtonClick()
        {
            base.OnButtonClick();
            AllServices.Container.Single<GameStateMachine>().Enter<GameLoopState>();
        }
    }
}