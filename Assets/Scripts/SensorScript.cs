using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    private AudioSource audioBeep;
    [SerializeField] private Light light;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float timer;
    private bool isLightOn = false;

    private bool coroutineRun = false;


    private void Awake()
    {
        MoveFishScript.isFishAlive = false;
    }
    void Start()
    {
        audioBeep = GetComponent<AudioSource>();
        audioBeep.loop = false;
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFishScript.isFishAlive && !coroutineRun)
        {
            coroutineRun = true;
            StartCoroutine(blinkLight());
        }
    }


    void SensorBeeping()
    {
        audioBeep.PlayOneShot(clip);
    }

    IEnumerator blinkLight()
    {
        while(MoveFishScript.isFishAlive && !isLightOn)
        {
            light.enabled = true;
            SensorBeeping();
            yield return new WaitForSeconds(0.3f);
            light.enabled = false;
            yield return new WaitForSeconds(timer);
            
        }

        coroutineRun = false;
    }
}
