
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongScene : MonoBehaviour, IMiniGame
{
    public string GameName => "Pong";

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
        SceneManager.LoadScene("GamePlay");
    }


    public void EndGame()
    {
        MiniGameManager.Instance.EndCurrentGame();
        SceneManager.LoadScene("Menu");
    }
}
