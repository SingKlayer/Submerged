using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject text;

    private PlayerUI playerUI;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        text.SetActive(false);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            
            if (hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                //text.SetActive(false);
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                hitInfo.collider.GetComponent<Interactable>().BaseInteract();
            }


        }
    }
}
