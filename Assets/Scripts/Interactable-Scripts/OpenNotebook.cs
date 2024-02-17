using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenNotebook : Interactable
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private SC_FPSController playerController;
    [SerializeField] private Button but;
    private AudioSource audio;
    private bool isUsing = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        playerController = GetComponent<SC_FPSController>();
    }
    protected override void Interact()
    {
        if (!isUsing)
        {
            SC_FPSController.canMove = true;
            text.SetActive(true);
            crosshair.SetActive(true);
        }
       
        if (Input.GetKey(KeyCode.E))
        {
            audio.Play();
            isUsing = true;
            lockPlayerMove();
            text.SetActive(false);
            crosshair.SetActive(false);
            panel.SetActive(true);
        }
    }

    public void closeNotebook()
    {
        panel.SetActive(false);
        crosshair.SetActive(true);
        text.SetActive(true);
        unlockPlayerMove();
    }

    private void lockPlayerMove()
    {
        SC_FPSController.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void unlockPlayerMove()
    {
        SC_FPSController.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}