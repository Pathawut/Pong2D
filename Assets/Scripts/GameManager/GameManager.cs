using Microsoft.Win32;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // -------- Singleton --------
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindFirstObjectByType<GameManager>();
                if (_instance == null)
                {
                    var go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    // Game System
    [SerializeField] private string[] GameScenes;
    [SerializeField] private IGame currentGame;

    
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

    public void RegisterGame(IGame game)
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
