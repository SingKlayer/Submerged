using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBrokeEvent : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject pipeAlarm;
    public static bool isBroken = false;


    void Start()
    {
        StartCoroutine(breakPipe());
        
    }


    IEnumerator breakPipe()
    {
        yield return new WaitForSeconds(160);
        pipeAlarm.SetActive(true);
        var emission = particle.emission;
        emission.enabled = true;
        audio.Play();
        isBroken = true;
    }



}
