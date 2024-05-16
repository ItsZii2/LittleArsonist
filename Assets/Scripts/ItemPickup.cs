using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject flameThrowerObj;
    public GameObject flameThrowerObjWoods;
    public GameObject progressBar;
    public GameObject pickupSoundObj;

    public ParticleSystem flameThrower;
    public AudioSource flameSound;
    private AudioSource pickUpSound;

    void Start()
    {
        progressBar.SetActive(false);
        pickUpSound = pickupSoundObj.GetComponent<AudioSource>();
        pickUpSound.Stop();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "flamethrower_woods" && Input.GetButtonDown("PickUp"))
        {
            flameThrowerObj.SetActive(true);
            flameThrowerObjWoods.SetActive(false);
            flameThrower.Stop();
            flameSound.Stop(); 
            progressBar.SetActive(true);
            pickUpSound.Play();
        }
    }
}
