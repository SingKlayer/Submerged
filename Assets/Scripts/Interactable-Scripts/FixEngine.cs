using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FixEngine : Interactable
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderGameObj;
    [SerializeField] private AudioSource audioExplosion;
    [SerializeField] private GameObject text;

    [SerializeField] private GameObject panel;

    protected override void Interact()
    {
        
        if (EngineBreakEvent.engineBreak)
        {
            text.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                slider.value += Time.deltaTime;
                sliderGameObj.SetActive(true);

                if (slider.value >= 26)
                {
                    //Debug.Log("cabo");
                    audioExplosion.Play();
                    panel.SetActive(true);
                    StartCoroutine(changeScene());
                    text.SetActive(false);
                    sliderGameObj.SetActive(false);
                    slider.value = 0;
                }
            }
            else if (!Input.GetMouseButton(0) && slider.value >= 0)
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

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Credits");
    }


}
