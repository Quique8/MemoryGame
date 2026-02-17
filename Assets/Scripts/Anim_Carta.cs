using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Carta : MonoBehaviour
{
    public void PlayDealAnimation()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetTrigger("Deal");
            Invoke("desactivarAnimacion", 3f);
        }
    }

    void desactivarAnimacion()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public void activarAnimacion()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
    }
}
