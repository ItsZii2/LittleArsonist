using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject flameThrowerObj;
    public GameObject flameThrowerObjWoods;
    public GameObject progressBar;

    public ParticleSystem flameThrower;
    public AudioSource flameSound;

    void Start()
    {
        progressBar.SetActive(false);
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
        }
    }
}
