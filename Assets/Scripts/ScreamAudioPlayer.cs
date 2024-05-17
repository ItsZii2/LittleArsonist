using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAudioPlayer : MonoBehaviour
{
    [SerializeField] private GameObject screamAudioSource;
    [SerializeField] private GameObject villigerObject;

    [SerializeField] private float detectionRange = 10f;

    private bool isFireSet = false;
    private bool isPlayerNearby = false;

    public Progress progressCheck;
    private AudioSource screamSound;


    void Start()
    {
        screamSound = screamAudioSource.GetComponent<AudioSource>();
        screamSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        isFireSet = progressCheck.fireStarted();
        if (isFireSet && isPlayerNearby)
        {
            PlayScream();
        }
    }

    void PlayScream()
    {
        if (screamAudioSource != null && !screamSound.isPlaying)
        {
            screamSound.Play();
            villigerObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }
}