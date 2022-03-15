using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelsCount = 5;
    [SerializeField] private float _additionalScale = 3f;
    [SerializeField] private Beam _beam;

    [Header("Platforms")]
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private BasicPlatform[] _basicPlatforms;

    private const int PlatformsOnBeamCount = 2;
    private const int OneLevelScale = 1;
    private const float StartAndFinishAdditionalScale = (float)OneLevelScale / PlatformsOnBeamCount;
    private const float DistanceBetweenPlatforms = 1f;

    public float BeamScaleY => (float)(_levelsCount * OneLevelScale + _additionalScale) / PlatformsOnBeamCount + StartAndFinishAdditionalScale;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        var newBeam = Instantiate(_beam, transform).transform;
        SetHeight(newBeam);

        var spawnPosition = newBeam.position;
        spawnPosition.y += newBeam.localScale.y - _additionalScale;

        SpawnPlatform(_startPlatform, ref spawnPosition, transform);

        SpawnRandomBasicPlatforms(_basicPlatforms, ref spawnPosition);

        SpawnPlatform(_finishPlatform, ref spawnPosition, transform);
    }

    private void SpawnPlatform(BasicPlatform platform, ref Vector3 position, Transform parent)
    {
        const float MaxAngle = 360f;
        var randomRotation = Quaternion.Euler(Vector3.up * Random.Range(0, MaxAngle));
        Instantiate(platform, position, randomRotation, parent);
        position.y -= DistanceBetweenPlatforms;
    }

    private void SetHeight(Transform beam)
    {
        var beamScale = beam.localScale;
        beamScale.y = BeamScaleY;
        beam.localScale = beamScale;
    }

    private void SpawnRandomBasicPlatforms(BasicPlatform[] basicPlatforms, ref Vector3 startSpawnPosition)
    {
        for (int _ = 0; _ < _levelsCount; _++)
        {
            SpawnPlatform(basicPlatforms[Random.Range(0, basicPlatforms.Length)], ref startSpawnPosition, transform);
        }
    }
}
