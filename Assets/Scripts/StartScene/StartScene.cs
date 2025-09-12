
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
