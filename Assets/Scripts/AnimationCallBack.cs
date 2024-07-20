using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCallBack : MonoBehaviour
{
    public delegate void AnimationEnd();
    public static AnimationEnd onAnimationEnd;

    public void PlayEffect()
    {
        onAnimationEnd?.Invoke();
    }
}
