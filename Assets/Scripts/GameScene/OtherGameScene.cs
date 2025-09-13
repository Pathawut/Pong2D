using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherGameScene : MonoBehaviour, IGame
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
        GameManager.Instance.RegisterGame(this);
        //SceneManager.LoadScene("OtherGamePlay");
    }

    public void EndGame()
    {
        GameManager.Instance.EndCurrentGame();
        SceneManager.LoadScene("Menu");
    }
}
