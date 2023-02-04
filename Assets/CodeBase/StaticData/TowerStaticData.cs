using CodeBase.Logic.Tower;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/TowerStaticData", fileName = "TowerStaticData")]
    public class TowerStaticData : ScriptableObject
    {
        [Range(1, 100)]
        [SerializeField] private int _levelId;
        [FormerlySerializedAs("_towerBuilder")] [SerializeField] private TowerBuilder prefab;

        public TowerBuilder Prefab => prefab;

        [Space(10)]
        [Header("Base")]
        [SerializeField] private int _levelCount = 8;
        [SerializeField] private float _levelHeight = 0.5f;
        [SerializeField] private float _additionalBeamHeight = 1f;

        [Space(10)]
        [Header("Rotation")]
        [Range(0, 360)]
        [SerializeField] private float _minRotationY;
        [Range(0, 360)]
        [SerializeField] private float _maxRotationY = 360f;

        public int LevelId => _levelId;

        public int LevelCount => _levelCount;

        public float LevelHeight => _levelHeight;

        public float AdditionalBeamHeight => _additionalBeamHeight;

        public float MinRotationY => _minRotationY;

        public float MaxRotationY => _maxRotationY;

        private void OnValidate()
        {
            if (_minRotationY >= _maxRotationY)
            {
                _minRotationY = _maxRotationY - 1;
            }
        }
    }
}