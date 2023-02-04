using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject instance = UnityEngine.Resources.Load<GameObject>(path);
            return Object.Instantiate(instance);
        }

        public GameObject Instantiate(string path, Vector3 position)
        {
            GameObject instance = UnityEngine.Resources.Load<GameObject>(path);
            return Object.Instantiate(instance, position, Quaternion.identity);
        }
    }
}