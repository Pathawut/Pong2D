using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCountGameScene : MonoBehaviour, IMiniGame
{
    public string GameName => "ClickCount";

    public void ClickStart()
    {
        Initialize();
    }

    public void ClickQuit()
    {
        EndGame();
    }

    public void Initialize()
    {
        MiniGameManager.Instance.RegisterGame(this);
        SceneManager.LoadScene("ClickCountGamePlay");
    }

    public void EndGame()
    {
        MiniGameManager.Instance.EndCurrentGame();
        SceneManager.LoadScene("Menu");
    }
}
