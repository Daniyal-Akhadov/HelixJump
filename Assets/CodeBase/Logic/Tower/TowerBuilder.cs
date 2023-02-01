using CodeBase.Extensions;
using CodeBase.Logic.Platform;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private int _levelCount = 5;
        [SerializeField] private float _levelHeight = 0.5f;
        [SerializeField] private float _additionalBeamHeight = 1f;
        [SerializeField] private GameObject _beam;
        [SerializeField] private SpawnBeamMarker _spawnBeamMarker;

        [FormerlySerializedAs("startBasePlatform")]
        [FormerlySerializedAs("_startPlatform")]
        [Header("Platforms")]
        [SerializeField] private StartPlatform startPlatform;

        [FormerlySerializedAs("_finishPlatform")] [SerializeField] private FinishBasePlatform finishBasePlatform;
        [SerializeField] private MiddleBasePlatform[] _middlePlatforms;

        [Header("Rotation")]
        [SerializeField] private float _minRotationY = 0f;

        [SerializeField] private float _maxRotationY = 360f;

        private const int BoundsPlatformCount = 2;

        private float BeamHeight =>
            (BoundsPlatformCount + _levelCount) * _levelHeight + _additionalBeamHeight;

        private float BeamScaleY =>
            (BeamHeight - _levelHeight) / 2f;

        private Quaternion RandomRotationY =>
            Quaternion.Euler(Vector3.up * Random.Range(_minRotationY, _maxRotationY));

        private MiddleBasePlatform RandomMiddleBasePlatform =>
            _middlePlatforms[Random.Range(0, _middlePlatforms.Length)];

        private void Awake()
        {
            Build();
        }

        private Vector3 SpawnPlatformPosition
        {
            get
            {
                Vector3 spawnPosition = _spawnBeamMarker.transform.position;
                spawnPosition.y = BeamHeight - _additionalBeamHeight - _levelHeight;
                return spawnPosition;
            }
        }

        private void Build()
        {
            GameObject newBeam = Instantiate(_beam, _spawnBeamMarker.transform.position, Quaternion.identity, transform);
            newBeam.transform.SetScaleY(BeamScaleY);

            Vector3 spawnPlatformPosition = SpawnPlatformPosition;
            SpawnPlatform(startPlatform, ref spawnPlatformPosition, Quaternion.identity, transform);

            for (int i = 0; i < _levelCount; i++)
            {
                SpawnPlatform(RandomMiddleBasePlatform, ref spawnPlatformPosition, RandomRotationY, transform);
            }

            SpawnPlatform(finishBasePlatform, ref spawnPlatformPosition, Quaternion.identity, transform);
        }

        private void SpawnPlatform(Platform.BasePlatform basePlatform, ref Vector3 position, Quaternion rotation, Transform parent)
        {
            Instantiate(basePlatform, position, rotation, parent);
            position.y -= _levelHeight;
        }
    }
}