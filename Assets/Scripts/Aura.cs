using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Aura : MonoBehaviour
{
    [SerializeField] private VisualEffect effect;
    [SerializeField] private GameObject ball, effectObj;

    private void OnEnable()
    {
        AnimationCallBack.onAnimationEnd += StartEffect;
        ball.SetActive(false);
        effect.SendEvent("OnStopFirst");
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
        effect.SendEvent("OnPlayFirst");
        yield return new WaitForSeconds(1.4f);
        effect.SendEvent("OnStopFirst");
        effect.SendEvent("OnPlay");
        ball.SetActive(true);
        yield return null;
    }
}
