using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomScript : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Sweep();
    }

    private void Sweep()
    {
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("IsSweeping", false);
            //anim.Play("Broom_Idle");
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsSweeping", true);
            //anim.Play("Broom_Sweeping");        
        }
    }
}
