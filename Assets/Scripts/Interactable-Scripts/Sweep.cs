using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sweep : Interactable
{
    [SerializeField] private GameObject sliderGameObj;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject text;
    [SerializeField] private AudioSource audioSweep;

    private TMPro.TMP_Text textMesh;

    private void Start()
    {
        textMesh = text.GetComponent<TMP_Text>();
        textMesh.text = "Varrer [Mouse Esquerdo]";
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) && GetBroom.isWithBroom)
        {
            audioSweep.enabled = true;
            sliderGameObj.SetActive(true);
            slider.value += Time.deltaTime;
            text.SetActive(true);
        } else if (Input.GetMouseButtonUp(0))
        {
            audioSweep.enabled = false;
        }

        if (!GetBroom.isWithBroom)
        {
            
            sliderGameObj.SetActive(false);
            text.SetActive(false);
        }
    }
}
