using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/WindowStaticData", fileName = "WindowStaticData")]
    public sealed class WindowStaticData : ScriptableObject
    {
        [SerializeField] private List<WindowConfig> _windowConfigs;

        public List<WindowConfig> WindowConfigs => _windowConfigs;
    }
}