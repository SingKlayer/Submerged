using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFishScript : MonoBehaviour
{

    [SerializeField] private float fishSpeed = 5f;

    public static bool isFishAlive = false;
    

    private void Awake()
    {
        isFishAlive = false;
    }
    void Start()
    {
        
    }

    
    void Update()
    {


        transform.position = transform.position + (Vector3.left * fishSpeed) * Time.deltaTime;       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DespawnFish")
        {
            isFishAlive = false;
            FishSpawnerScript.isCoroutineRun = false;
            Destroy(gameObject);
        }
    }
}
