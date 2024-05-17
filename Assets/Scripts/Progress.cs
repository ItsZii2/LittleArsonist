using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    public Slider progressSlider;
    public float maxProgress = 100f;
    public float progress;
    public FireController fireController;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        progress = fireController.GetFireUsed();

        if (progressSlider.value != progress)
        {
            progressSlider.value = progress;
        }

        if (progressSlider.value >= 100f)
        {
            gameEnd();
        }

    }

    void gainProgress(float gain)
    {
        progress += gain;
    }

    public float getProgress()
    {
        return progress;
    }

    public bool fireStarted()
    {
        if (progress >=10f) 
        {
            return true;
        } else
        {
            return false;
        }
    }

    void gameEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Initiate.Fade("EndScene", Color.black, 1.0f);
    }
}
