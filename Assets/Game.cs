using UnityEngine;

public class Game : MonoBehaviour
{
    private Menu _menu;
    private FinishPlatform _finishPlatform;

    private void Start()
    {
        _finishPlatform = FindObjectOfType<FinishPlatform>();
        _finishPlatform.Reached += OnFinishReached;
        _menu = FindObjectOfType<Menu>();
    }

    private void OnDisable()
    {
        _finishPlatform.Reached -= OnFinishReached;
    }

    private void OnFinishReached()
    {
        _menu.Show();
    }
}
