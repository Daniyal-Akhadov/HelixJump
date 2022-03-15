using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        const int MaxAlpha = 1;
        _canvasGroup.alpha = MaxAlpha;
    }

    public void StartGame()
    {
        const int MaxAlpha = 0;
        _canvasGroup.alpha = MaxAlpha;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
