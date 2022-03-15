using System;
using UnityEngine;

public class FinishPlatform : BasicPlatform
{
    public event Action Reached;

    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Reached?.Invoke();
        }

        print("Collision platfrom finish");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger platfrom finish");
    }
}
