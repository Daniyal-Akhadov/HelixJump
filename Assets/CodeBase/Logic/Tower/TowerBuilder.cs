using CodeBase.Extensions;
using CodeBase.Logic.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject _beam;
        [SerializeField] private SpawnBeamMarker _spawnBeamMarker;

        [Header("Platforms")]
        [SerializeField] private StartPlatform _startPlatform;

        [SerializeField] private FinishBasePlatform _finishBasePlatform;
        [SerializeField] private MiddleBasePlatform[] _middlePlatforms;

        public int LevelCount { get; set; } = 5;
        public float LevelHeight { get; set; } = 0.5f;
        public float AdditionalBeamHeight { get; set; } = 1f;
        public float MinRotationY { get; set; } = 0f;
        public float MaxRotationY { get; set; } = 360f;

        private const int BoundsPlatformCount = 2;

        private float BeamHeight =>
            (BoundsPlatformCount + LevelCount) * LevelHeight + AdditionalBeamHeight;

        private Vector3 SpawnPlatformPosition
        {
            get
            {
                Vector3 spawnPosition = _spawnBeamMarker.transform.position;
                spawnPosition.y = BeamHeight - AdditionalBeamHeight - LevelHeight;
                return spawnPosition;
            }
        }

        private float BeamScaleY =>
            (BeamHeight - LevelHeight) / 2f;

        private Quaternion RandomRotationY =>
            Quaternion.Euler(Vector3.up * Random.Range(MinRotationY, MaxRotationY));

        private MiddleBasePlatform RandomMiddleBasePlatform =>
            _middlePlatforms[Random.Range(0, _middlePlatforms.Length)];

        public void Build()
        {
            CreateBeam();
            Vector3 spawnPlatformPosition = SpawnPlatformPosition;
            CreatePlatforms(spawnPlatformPosition);
        }

        private void CreateBeam()
        {
            GameObject newBeam = Instantiate(_beam, _spawnBeamMarker.transform.position, Quaternion.identity, transform);
            newBeam.transform.SetScaleY(BeamScaleY);
        }

        private void CreatePlatforms(Vector3 spawnPlatformPosition)
        {
            SpawnPlatform(_startPlatform, ref spawnPlatformPosition, Quaternion.identity, transform);
            CreateMiddlePlatforms(ref spawnPlatformPosition);
            SpawnPlatform(_finishBasePlatform, ref spawnPlatformPosition, Quaternion.identity, transform);
        }

        private void CreateMiddlePlatforms(ref Vector3 spawnPlatformPosition)
        {
            for (int i = 0; i < LevelCount; i++)
            {
                SpawnPlatform(RandomMiddleBasePlatform, ref spawnPlatformPosition, RandomRotationY, transform);
            }
        }

        private void SpawnPlatform(BasePlatform basePlatform, ref Vector3 position, Quaternion rotation, Transform parent)
        {
            Instantiate(basePlatform, position, rotation, parent);
            position.y -= LevelHeight;
        }
    }
}