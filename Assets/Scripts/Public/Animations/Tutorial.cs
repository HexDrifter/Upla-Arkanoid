using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup.alpha = 0;
        
        StartCoroutine(Fade());
    }


    IEnumerator Fade()
    {
        canvasGroup.DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);
        canvasGroup.DOFade(0f,1f);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
