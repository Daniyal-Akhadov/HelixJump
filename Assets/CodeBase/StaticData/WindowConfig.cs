using System;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Window;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public sealed class WindowConfig
    {
        [SerializeField] private WindowId _windowId;
        [SerializeField] private BaseWindow _prefab;

        public WindowId WindowId => _windowId;

        public BaseWindow Prefab => _prefab;
    }
}