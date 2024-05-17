using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject flameThrowerObj;
    public GameObject flameThrowerObjWoods;

    public GameObject progressBar;
    public GameObject instructions;

    public GameObject pickupSoundObj;
    public GameObject burningBeginningSoundObj;
    public GameObject endGameSoundObj;

    public ParticleSystem flameThrower;

    public AudioSource flameSound;
    private AudioSource pickUpSound;

    private AudioSource beginningSound;
    private AudioSource endGameSound;


    private Progress progress;
    private float gameProgress;

    private bool beginningSoundPlaying;
    private bool endGameSoundPlaying;

    void Start()
    {
        progressBar.SetActive(false);
        instructions.SetActive(false);
        pickUpSound = pickupSoundObj.GetComponent<AudioSource>();
        pickUpSound.Stop();

        progress = progressBar.GetComponent<Progress>();

        beginningSound = burningBeginningSoundObj.GetComponent<AudioSource>();
        beginningSound.Stop();

        endGameSound = endGameSoundObj.GetComponent<AudioSource>();
        endGameSound.Stop();

        endGameSoundPlaying = false;
        beginningSoundPlaying = false;
    }

    void Update()
    {
        gameProgress = progress.getProgress();
        if (gameProgress > 30f && !beginningSoundPlaying)
        {
            beginningSound.Play();
            beginningSoundPlaying = true;
        }
        if (gameProgress > 70f && !endGameSoundPlaying)
        {
            endGameSound.Play();
            endGameSoundPlaying = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "flamethrower_woods")
        {
            instructions.SetActive(true);
        }
        if (other.name == "flamethrower_woods" && Input.GetButtonDown("PickUp"))
        {
            flameThrowerObj.SetActive(true);
            flameThrowerObjWoods.SetActive(false);
            flameThrower.Stop();
            flameSound.Stop(); 
            progressBar.SetActive(true);
            pickUpSound.Play();
            instructions.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        instructions.SetActive(false);
    }
}
