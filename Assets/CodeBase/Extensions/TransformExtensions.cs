using UnityEngine;

namespace CodeBase.Extensions
{
    public static class TransformExtensions
    {
        public static void SetScaleY(this Transform transform, float value)
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x, value, localScale.z);
            transform.localScale = localScale;
        }
    }
}