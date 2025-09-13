using Microsoft.Win32;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    // -------- Singleton --------
    private static MiniGameManager _instance;
    public static MiniGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindFirstObjectByType<MiniGameManager>();
                if (_instance == null)
                {
                    var go = new GameObject("MiniGameManager");
                    _instance = go.AddComponent<MiniGameManager>();
                }
            }
            return _instance;
        }
    }

    // Game System
    [SerializeField] private string[] GameScenes;
    [SerializeField] private IMiniGame currentGame;

    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LaunchGame(int id)
    {
        if (id >= 0 && id < GameScenes.Length)
        {
            SceneManager.LoadScene(GameScenes[id]);
        }
    }

    public void RegisterGame(IMiniGame game)
    {
        if (currentGame != game)
        {
            currentGame = game;
        }
    }

    public void EndCurrentGame()
    {
        if (currentGame != null)
        {
            currentGame = null;
        }
    }
}
