using System;
using CodeBase.Logic.Platform;
using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class BallPlatformBreaker : MonoBehaviour
    {
        public event Action<int> OnBroken;

        private int _currentPlatform;

        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rigidbody = other.attachedRigidbody;

            if (rigidbody != null)
            {
                if (rigidbody.TryGetComponent(out PlatformSegment segment))
                {
                    BasePlatform basePlatform = segment.GetComponentInParent<BasePlatform>();

                    if (basePlatform != null)
                    {
                        basePlatform.Break();
                        _currentPlatform++;
                        OnBroken?.Invoke(_currentPlatform);
                    }
                }
            }
        }
    }
}