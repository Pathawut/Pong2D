using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public void Game1Clicked()
    {
        GameManager.Instance.LaunchGame(0);
    }

    public void Game2Clicked()
    {
        GameManager.Instance.LaunchGame(1);
    }
}
