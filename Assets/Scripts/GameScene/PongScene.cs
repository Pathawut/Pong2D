
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongScene : MonoBehaviour, IGame
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
        GameManager.Instance.RegisterGame(this);
        SceneManager.LoadScene("GamePlay");
    }


    public void EndGame()
    {
        GameManager.Instance.EndCurrentGame();
        SceneManager.LoadScene("Menu");
    }
}
