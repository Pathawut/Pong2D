using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public void Game1Clicked()
    {
        MiniGameManager.Instance.LaunchGame(0);
    }

    public void Game2Clicked()
    {
        MiniGameManager.Instance.LaunchGame(1);
    }
}
