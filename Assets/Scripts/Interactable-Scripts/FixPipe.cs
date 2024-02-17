using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixPipe : Interactable
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderGameObj;
    
    [SerializeField] private GameObject text;

    [SerializeField] private AudioSource audioPipe;
    [SerializeField] private ParticleSystem particlePipe;
    [SerializeField] private GameObject alarmPipe;

    bool isOver = false;
    bool isFixed = false;



    protected override void Interact()
    {
        if (!isFixed && PipeBrokeEvent.isBroken)
        {
         text.SetActive(true);
            if (Input.GetMouseButton(0) && !isOver)
            {
                
                slider.value += Time.deltaTime;
                sliderGameObj.SetActive(true);

                if (slider.value == 5)
                {
                    isOver = true;
                    alarmPipe.SetActive(false);
                    var emission = particlePipe.emission;
                    emission.enabled = false;
                    audioPipe.Stop();
                    text.SetActive(false);
                    isFixed = true;
                    PipeBrokeEvent.isBroken = false;
                    sliderGameObj.SetActive(false);
                    slider.value = 0;
                }
            }
            else if (!Input.GetMouseButton(0) && slider.value >= 0 && !isOver)
            {
                slider.value -= Time.deltaTime;

                if (slider.value <= 0)
                {
                    slider.value = 0;
                    sliderGameObj.SetActive(false);
                }
            }
        }
        

    }


}
