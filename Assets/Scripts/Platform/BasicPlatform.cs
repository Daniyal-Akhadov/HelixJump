using UnityEngine;

public class BasicPlatform : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 50f;
    [SerializeField] private float _bounceRadius = 50f;

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();

        if (segments != null)
        {
            foreach (var segment in segments)
            {
                segment.Bounce(_bounceForce, transform.position, _bounceRadius);
            }
        }
    }
}
