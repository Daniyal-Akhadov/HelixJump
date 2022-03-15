using UnityEngine;

public class StartPlatform : BasicPlatform
{
    [SerializeField] private Transform _spawPoint;
    [SerializeField] private Ball _ball;

    private void Awake()
    {
        Instantiate(_ball, _spawPoint.position, Quaternion.identity);
    }
}
