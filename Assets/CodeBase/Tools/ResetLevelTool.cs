using CodeBase.Infrastructure.GameStates;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Tools
{
    public sealed class ResetLevelTool : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AllServices.Container.Single<GameStateMachine>().Enter<BootstrapState>();
            }
        }
    }
}