using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Resources.GameLogic.Utility
{
    public class MonoPoolService<T> : IService where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly bool _autoExpand;
        private readonly Transform _container;

        private List<T> _pool;

        public MonoPoolService(T prefab, int count, Transform container, bool autoExpand = false)
        {
            _prefab = prefab;
            _container = container;
            _autoExpand = autoExpand;
            CreatePool(count);
        }

        public T GetFreeElement(Vector3 position, Quaternion rotation)
        {
            T freeElement = GetFreeElement();
            freeElement.transform.SetPositionAndRotation(position, rotation);
            return freeElement;
        }

        public T GetFreeElement()
        {
            T result;

            if (HasFreeElement(out T element))
                result = element;
            else if (_autoExpand == true)
                result = CreateObject();
            else
                throw new Exception($"There is no free element in pool of this type {typeof(T)}");

            result.gameObject.SetActive(true);
            return result;
        }

        private bool HasFreeElement(out T element)
        {
            T result = null;

            foreach (T monoObject in _pool)
            {
                if (monoObject.gameObject.activeInHierarchy == false)
                {
                    result = monoObject;
                    break;
                }
            }

            element = result;
            return element != null;
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>(count);

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            T createObject = Object.Instantiate(_prefab, _container);
            createObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createObject);
            return createObject;
        }
    }
}