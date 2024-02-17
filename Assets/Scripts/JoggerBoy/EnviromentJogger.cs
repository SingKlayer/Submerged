using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class EnviromentJogger : MonoBehaviour
{
    public float sendTimer = 1;
    public float frequency = 2;
    public float position;
    public GameObject myObstacle;
    //public GameObject mainCharacter;
    void Update()
    {
        sendTimer -= Time.deltaTime;
        if (sendTimer <= 0)
        {
            position = Random.Range(-10.38f, -14.30f);
            transform.position = new Vector3(4.6f, position, transform.position.z);
            Instantiate(myObstacle, transform.position, transform.rotation);
            sendTimer = frequency;
        }


    }
}