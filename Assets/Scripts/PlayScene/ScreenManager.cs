using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public enum SceneState
    {
        Start,
        Play,
        Fail,
        Win,
    }

    public Text HeaderText;
    public Text SubText;
    public Text BottomText;
    public Text SceneText;
    public BrickManager brickManager;
    public Ball ball;

    public TextAsset[] sceneScript;

    private SceneState state;
    private int currentScene = 0;
    private int maxScene;
    private int live = 3;

    void Start()
    {
        ball.gameObject.SetActive(false);
        maxScene = sceneScript.Length;

        SetState(SceneState.Start); 
    }

    private void LoadSceneAsset(TextAsset asset)
    {
       if (asset != null)
       {
            var content = asset.text;
            var AllWords = content.Split('\n');
            var lines = new List<string>(AllWords);

            var brickScripts = GetBrickScripts(lines);
            brickManager.CreateBricks(brickScripts);
       }
    }

    private List<BrickScript> GetBrickScripts(List<string> lines)
    {
        List<BrickScript> brickScripts = new List<BrickScript>();

        foreach (var line in lines)
        {
            if (!line.StartsWith("//"))
            {
                string[] stringSplit = line.Split(',');
                if (stringSplit.Length == 3)
                {
                    int type = int.Parse(stringSplit[0]);
                    float x = float.Parse(stringSplit[1]);
                    float y = float.Parse(stringSplit[2]);
                    BrickScript script = new BrickScript(type, new Vector2(x, y));

                    brickScripts.Add(script);
                }
            }
        }

        return brickScripts;
    }

    public void OnFinish(int current)
    {
        if (current < maxScene)
        {
            SceneText.text = $"Level {currentScene+1}";
            LoadSceneAsset(sceneScript[current]);
            currentScene++;
        }
        else
        {
            SetState(SceneState.Win);
        }
    }

    public void SetState(SceneState newState)
    {
        switch(newState)
        {
            case SceneState.Start:
                {
                    HeaderText.gameObject.SetActive(false);
                    SubText.gameObject.SetActive(false);
                    SetLive(live);
                    SceneText.text = $"Level {currentScene + 1}";
                    LoadSceneAsset(sceneScript[currentScene]);
                    currentScene++;
                    ball.gameObject.SetActive(true);
                    ball.Reset();
                    state = SceneState.Play;
                }
                break;

            case SceneState.Win:
                {
                    ball.Stop();
                    HeaderText.text = "You Win!!!";
                    SubText.text = "back to title";
                    HeaderText.gameObject.SetActive(true);
                    SubText.gameObject.SetActive(true);
                    state = SceneState.Win;
                }
                break;

            case SceneState.Fail:
                {
                    ball.Stop();
                    HeaderText.text = "You Lose!!! ";
                    SubText.text = "back to title";
                    HeaderText.gameObject.SetActive(true);
                    SubText.gameObject.SetActive(true);
                    state = SceneState.Fail;
                }
                break;
        }
    }

    public bool Death()
    {
        live--;
        SetLive(live);
        if (live > 0)
        {
            return true;
        }

        live = 0;
        SetLive(0);
        SetState(SceneState.Fail);

        return false;
    }

    public void SetLive(int live)
    {
        BottomText.text = $"Ball x {live}";
    }

    public void Finish()
    {
        OnFinish(currentScene);
    }

    void Update()
    {
        if (state == SceneState.Win || state == SceneState.Fail)
        {
            if((Input.touchCount > 0) || (Input.anyKey))
            {
                SceneManager.LoadScene("StartGame");
            }
        }
    }
}
