using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixO2 : Interactable
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderGameObj;

    [SerializeField] private AudioSource audioO2;
    [SerializeField] private ParticleSystem particleO2;
    [SerializeField] private GameObject alarmO2;

    [SerializeField] private GameObject text;

    bool isOver = false;
    bool isFixed = false;



    protected override void Interact()
    {
        if (!isFixed && O2BrokenEvent.isBroken)
        {
            text.SetActive(true);
            if (Input.GetMouseButton(0) && !isOver)
            {
                slider.value += Time.deltaTime;
                sliderGameObj.SetActive(true);

                if (slider.value == 5)
                {
                    isOver = true;
                    alarmO2.SetActive(false);
                    var emission = particleO2.emission;
                    emission.enabled = false;
                    audioO2.Stop();
                    text.SetActive(false);
                    isFixed = true;
                    O2BrokenEvent.isBroken = false;
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
