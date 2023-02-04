using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class Splash : MonoBehaviour
    {
        private readonly WaitForSeconds _deactivateInTime = new(8f);

        private void Start()
        {
            StartCoroutine(DeactivateInTime());
        }

        private IEnumerator DeactivateInTime()
        {
            yield return _deactivateInTime;
            gameObject.SetActive(false);
        }
    }
}