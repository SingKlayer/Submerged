using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestProgressBar : MonoBehaviour
{
    [SerializeField] public Slider slider;

    bool isOver = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && !isOver)
        {
            slider.value += Time.deltaTime;

            if (slider.value == 1) 
            {
               
                isOver = true;
                Debug.Log("cabo");
            }

        } else if (!Input.GetKey(KeyCode.E) && slider.value >=0 && !isOver)
        {
            slider.value -= Time.deltaTime;
        }
    }
}
