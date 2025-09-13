using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OtherManager : MonoBehaviour
{
    public enum SceneState
    {
        Start,
        Play,
        Fail,
        Win,
    }

    private SceneState state;
    private float CountdownTime = 5f;
    private float time;

    public Text HeaderText;
    public Text SubText;

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
                SceneManager.LoadScene("OtherStart");
            }
        }
        else if (state == SceneState.Play)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0f;
                SetState(SceneState.Win);
            }

            HeaderText.text = time.ToString("N0");
        }
    }

    public void SetState(SceneState newState)
    {
        switch (newState)
        {
            case SceneState.Start:
                {
                    HeaderText.gameObject.SetActive(true);
                    state = SceneState.Play;

                    time = CountdownTime;
                }
                break;

            case SceneState.Win:
                {
                    HeaderText.gameObject.SetActive(false);

                    SubText.text = "back to title";
                    
                    SubText.gameObject.SetActive(true);
                    state = SceneState.Win;
                }
                break;
        }
    }
}
