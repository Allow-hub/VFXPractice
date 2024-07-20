using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class Aura : MonoBehaviour
{
    [SerializeField] private VisualEffect effect;
    
    [SerializeField] private GameObject ball,effectObj;
    private void OnEnable()
    {
        AnimationCallBack.onAnimationEnd += StartEffect;
        ball.SetActive(false);
        effect.SendEvent("OnStop1");
        effect.SendEvent("OnStop");
    }

    private void OnDisable()
    {
        AnimationCallBack.onAnimationEnd -= StartEffect;
    }
    public void StartEffect()
    {
        StartCoroutine(PlayEffect());

    }

    IEnumerator PlayEffect()
    {
        effect.SendEvent("OnPlay1");
        yield return new WaitForSeconds(1.4f);
        effect.SendEvent("OnStop1");
        effect.SendEvent("OnPlay");
        yield return new WaitForSeconds(0.3f);
        ball.SetActive(true);

        yield return null;
    }
}
