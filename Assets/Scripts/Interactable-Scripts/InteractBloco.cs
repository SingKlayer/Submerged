using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractBloco : Interactable
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject text;
    protected override void Interact()
    {
        text.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            text.SetActive(false);
            panel.SetActive(true);
            Debug.Log("interacted with" + gameObject.name);
        }
    }
}
