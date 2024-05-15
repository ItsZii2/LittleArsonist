using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string scene;
    public Color loadToColor = Color.black;

    

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "OpeningScene")
        {
            StartCoroutine(WaitTime(7));
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void startGame()
    {
        Initiate.Fade("Game", loadToColor, 1.0f);
    }
    public void showInstructions()
    {
        SceneManager.LoadScene(4);
    }
    IEnumerator WaitTime(int time)
    {
        yield return new WaitForSeconds(time);
        Initiate.Fade("StartScene", loadToColor, 2.0f);
    }
}
