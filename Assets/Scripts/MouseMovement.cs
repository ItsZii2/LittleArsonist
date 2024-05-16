using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float YRotation = 0f;
    

    public ParticleSystem flameThrower;
    public AudioSource flameSound;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;

        flameThrower.Stop();
        flameSound.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flameThrower.Play();
            flameSound.Play();

        }
        if (Input.GetMouseButtonUp(0))
        {
            flameThrower.Stop();
            flameSound.Stop();
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -65f, 40f); //(rotation sideways, rotation up, rotation down)

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);

    }
    public bool IsFlameThrowerPlaying()
    {
        return flameThrower.isPlaying;
    }
}
