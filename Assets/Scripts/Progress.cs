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
    public GameObject burningBeginningSoundObj;
    public GameObject endGameSoundObj;

    private AudioSource beginningSound;
    private AudioSource endGameSound;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
        beginningSound = burningBeginningSoundObj.GetComponent<AudioSource>();
        beginningSound.Stop();
        endGameSound = endGameSoundObj.GetComponent<AudioSource>();
        endGameSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        progress = fireController.GetFireUsed();
        print("Current game progress: " + progress);

        if (progressSlider.value != progress)
        {
            progressSlider.value = progress;
        }

        if (progressSlider.value >= 100f)
        {
            gameEnd();
        }
        if (progressSlider.value >= 30f)
        {
            beginningSound.Play();
        }
        if (progressSlider.value >= 70f)
        {
            endGameSound.Play();
        }

    }

    void gainProgress(float gain)
    {
        progress += gain;
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
