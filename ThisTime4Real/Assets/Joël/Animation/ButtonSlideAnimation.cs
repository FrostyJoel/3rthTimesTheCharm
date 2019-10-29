using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSlideAnimation : MonoBehaviour
{
    public Animator anim;
    public bool opend;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CheckIfOpen()
    {
        if (opend)
        {
            ResetTriggers();
            anim.SetTrigger("Close");
            opend = false;
        }
        else
        {
            ResetTriggers();
            anim.SetTrigger("Open");
            opend = true;
        }
    }
    public void ResetTriggers()
    {
        anim.ResetTrigger("Close");
        anim.ResetTrigger("Open");
    }
}
