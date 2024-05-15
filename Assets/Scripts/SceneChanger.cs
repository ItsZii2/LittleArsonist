using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void startGame()
    {
        SceneManager.LoadScene(0);
    }
    public void showInstructions()
    {
        SceneManager.LoadScene(3);
    }
}
