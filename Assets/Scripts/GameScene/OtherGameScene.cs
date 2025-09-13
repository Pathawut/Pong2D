using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherGameScene : MonoBehaviour, IMiniGame
{
    public string GameName => "Other";

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
        //SceneManager.LoadScene("OtherGamePlay");
    }

    public void EndGame()
    {
        MiniGameManager.Instance.EndCurrentGame();
        SceneManager.LoadScene("Menu");
    }
}
