using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class EntryPointRunner : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;

        private void Awake()
        {
            EntryPoint otherEntryPoint = FindObjectOfType<EntryPoint>();

            if (otherEntryPoint == null)
            {
                Instantiate(_entryPoint, transform.position, Quaternion.identity);
            }
        }
    }
}