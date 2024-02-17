using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class EngineBreakEvent : Interactable
{
    [SerializeField] private GameObject lights;
    [SerializeField] private AudioSource engineAudio;
    [SerializeField] private GameObject tela;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource powerDown;

  

    public static bool engineBreak = false;

    private bool coroutineRun = false;
    

    private void Update()
    {
        if (FishSpawnerScript.hasAll  && !coroutineRun && FishSpawnerScript.dinoAppear)
        {
            StartCoroutine(breakEngine());
        }
    }


    IEnumerator breakEngine()
    {
        coroutineRun = true;
        FishSpawnerScript.canSpawn = false;
        yield return new WaitForSeconds(30); 
        powerDown.Play();
        lights.SetActive(false);
        engineAudio.Stop();
        tela.SetActive(false);
        var emission = particles.emission;
        emission.enabled = false;
        engineBreak = true;

    }


}
