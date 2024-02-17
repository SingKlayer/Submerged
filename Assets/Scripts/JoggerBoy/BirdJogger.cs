using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJogger : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float flapStrength;
    [SerializeField] AudioSource myaudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            myaudio.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

    }
}
