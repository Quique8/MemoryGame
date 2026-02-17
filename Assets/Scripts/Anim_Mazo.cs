using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Mazo : MonoBehaviour
{
    public bool isAnimationFinished = false;
    public void OnAnimationEnd()
    {
        isAnimationFinished = true;
    }
}
