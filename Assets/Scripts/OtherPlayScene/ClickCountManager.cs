using System.Runtime.Remoting.Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickCountManager : MonoBehaviour
{
    public enum SceneState
    {
        Start,
        Play,
        Fail,
        Win,
    }

    public int MaxCount = 20;
    private SceneState state;
    private float CountdownTime = 5f;
    private float time;
    private int count = 0;

    public Text HeaderText;
    public Text SubText;
    public Text CountText;

    void Start()
    {
        SetState(SceneState.Start);
    }

    
    void Update()
    {
        if (state == SceneState.Win || state == SceneState.Fail)
        {
            if ((Input.touchCount > 0) || (Input.anyKey))
            {
                SceneManager.LoadScene("ClickCountStart");
            }
        }
        else if (state == SceneState.Play)
        {
            if (Input.anyKeyDown)
            {
                count++;
            }

            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0f;
                UpdateUI();

                if (count >= MaxCount)
                {
                    SetState(SceneState.Win);
                }
                else
                {
                    SetState(SceneState.Fail);
                }  
            }
            else
            {
                UpdateUI();
            }  
        } 
    }

    public void SetState(SceneState newState)
    {
        switch (newState)
        {
            case SceneState.Start:
                {
                    HeaderText.gameObject.SetActive(true);
                    CountText.gameObject.SetActive(true);
                    state = SceneState.Play;

                    time = CountdownTime;
                    count = 0;
                }
                break;

            case SceneState.Win:
                {
                    HeaderText.text = "You Win!!!";
                    SubText.text = "back to title";
                    HeaderText.gameObject.SetActive(true);
                    SubText.gameObject.SetActive(true);
                    state = SceneState.Win;
                }
                break;


            case SceneState.Fail:
                {
                    HeaderText.text = "You Lose!!! ";
                    SubText.text = "back to title";
                    HeaderText.gameObject.SetActive(true);
                    SubText.gameObject.SetActive(true);
                    state = SceneState.Fail;
                }
                break;
        }
    }

    public void UpdateUI()
    {
        HeaderText.text = time.ToString("N0");
        CountText.text = "Count : " + count.ToString();
    }
}
