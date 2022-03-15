using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var segment = other.GetComponent<PlatformSegment>();

        if (segment != null)
        {
            segment.GetComponentInParent<BasicPlatform>().Break();
        }
    }
}
