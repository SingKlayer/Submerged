using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnerScript : MonoBehaviour
{


    [SerializeField] private GameObject[] fishArray;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] GameObject fishAlarm;
    [SerializeField] AudioSource audio;
    public static bool canSpawn = true;
    private bool hasSmall = false;
    private bool hasLarge = false;
    private bool hasMedium = false;
    [SerializeField] public static bool hasAll = false;
    public static bool dinoAppear = false;
    public static bool isCoroutineRun = false;
    private Vector3 spawnPosition = new Vector3(6, 3.5f, 9.5f);
    private int fishIndex = 0;
    


    // Update is called once per frame
    void Update()
    {
        if (!MoveFishScript.isFishAlive && !isCoroutineRun)
        {
            isCoroutineRun = true;
            StartCoroutine(timerToSpawn());
        }

        if (MoveFishScript.isFishAlive)
        {
            fishAlarm.SetActive(true);
        }
        else
        {
            fishAlarm.SetActive(false);
        }
    }


    private void SpawnFish()
    {

        if(fishIndex >= 3)
        {
            fishIndex = 3;
        }
        Quaternion fishRotation = Quaternion.identity;


        
        if (hasAll)
        {
            dinoAppear = true;
            fishIndex = 3;
            spawnPosition = new Vector3(16, 3, 14);
            fishRotation = Quaternion.Euler(-90, 0, -90);
            audio.Play();
        }
        else if (fishIndex == 0 || fishIndex == 2)
        {
            fishRotation = Quaternion.Euler(-90, 0, 270);
        }
        else if (fishIndex == 1)
        {
            fishRotation = Quaternion.Euler(90, 0, 90);
        }
        

        Instantiate(fishArray[fishIndex], spawnPosition, fishRotation);
        checkForFish(fishIndex);
        fishIndex += 1;
    }

    IEnumerator timerToSpawn()
    {

        
        float wait_time = Random.Range(minTime, maxTime);
        

        yield return new WaitForSeconds(wait_time);
        if (canSpawn)
        {
            SpawnFish();
            MoveFishScript.isFishAlive = true;
        }
        
        

    }

    private void checkForFish(int fishIndex)
    {
        if(fishIndex == 0)
        {
            hasSmall = true;
        }else if(fishIndex == 1)
        {
            hasLarge = true;
        }else if(fishIndex == 2)
        {
            hasMedium = true;
        }

        if(hasSmall && hasLarge && hasMedium)
        {
            hasAll = true;
        }

        
    }
}
