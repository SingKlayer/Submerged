using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class O2BrokenEvent : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject O2Alarm;
    public static bool isBroken = false;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(breakO2());
    }




    IEnumerator breakO2()
    {
        yield return new WaitForSeconds(90);
        O2Alarm.SetActive(true);
        particle.Play();
        var emission = particle.emission;
        emission.enabled = true;
        audio.Play();
        isBroken = true;
    }
}
