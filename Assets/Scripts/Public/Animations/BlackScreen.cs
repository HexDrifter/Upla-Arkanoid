using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    public static BlackScreen instance;
    [SerializeField] public CanvasGroup canvasGroup;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(FadeOut());

    }

    public IEnumerator FadeOut()
    {
        
        canvasGroup.alpha = 1f;
        canvasGroup.DOFade(0f, 1f);
        yield return new WaitForSeconds(1);
        canvasGroup.gameObject.SetActive(false);
    }


    public Tween FadeIn()
    {
        Debug.Log("Inicia Fade In");
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        return canvasGroup.DOFade(1f, 1f);
        

    }

    public void FadeIn(float time)
    {
        Debug.Log("Inicia Fade In");
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, time);
    }
}
