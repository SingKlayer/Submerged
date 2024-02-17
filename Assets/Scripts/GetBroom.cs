using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBroom : Interactable
{
    [SerializeField] GameObject broomSubmarine;
    [SerializeField] GameObject broomPlayer;
    [SerializeField] private GameObject text;
    bool canClick = true;
    public static bool isWithBroom = false;


    protected override void Interact()
    {
        if (canClick && !isWithBroom)
        {
            promptMessage = "Pegar Vassoura [E]";
            text.SetActive(true);
            getBroom();
        }
        else if (canClick && isWithBroom)
        {
            text.SetActive(true);
            promptMessage = "Devolver Vassoura [E]";
            putBroomBack(); 
        }

    }
    
    private void getBroom()
    {
        if (Input.GetKey(KeyCode.E))
        {
            canClick = false;
            isWithBroom = true;
            StartCoroutine(waitToUse());
            MeshRenderer broomMesh = broomSubmarine.GetComponent<MeshRenderer>();
            broomMesh.enabled = false;
            broomPlayer.SetActive(true);
        }
    }

    private void putBroomBack()
    {
        if (Input.GetKey(KeyCode.E))
        {
            canClick = false;
            isWithBroom = false;
            StartCoroutine(waitToUse());
            MeshRenderer broomMesh = broomSubmarine.GetComponent<MeshRenderer>();
            broomMesh.enabled = true;
            broomPlayer.SetActive(false);
            
        }
    }

    IEnumerator waitToUse()
    {
        yield return new WaitForSeconds(0.2f);
        canClick = true;
  
    }

    
}
