using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public Animator animator;

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }
}
