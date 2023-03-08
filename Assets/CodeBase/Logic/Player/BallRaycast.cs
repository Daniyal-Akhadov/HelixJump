using System;
using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public sealed class BallRaycast : MonoBehaviour
    {
        [SerializeField] private LayerMask _target;

        private float _length;

        public event Action<Vector3> NextPlatform;

        public void Construct(TowerBuilder towerBuilder)
        {
            _length = towerBuilder.LevelHeight;
        }

        private void Update()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _length, _target))
            {
                Debug.Log($"Sobytie {hit.point}");
                NextPlatform?.Invoke(hit.point);
            }
        }
    }
}