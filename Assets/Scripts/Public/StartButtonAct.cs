using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonAct : MonoBehaviour
{
    public void OnClickStartNewGameButton()
    {
        StartCoroutine(WaitAndStart());
        
    }
    IEnumerator WaitAndStart()
    {
        yield return BlackScreen.instance.FadeIn().WaitForCompletion();
        SceneManager.LoadScene("Level1");

        if (GameSystem.instance.levelSetup != null)
        {
            GameSystem.instance.levelSetup.playerHandler = new UplaArk.Framework.PlayerHandler();
        }
    }
    public void OnClickBackMenuButton()
    {
        StartCoroutine (WaitAndGoBack());
    }

    IEnumerator WaitAndGoBack()
    {
        yield return BlackScreen.instance.FadeIn().WaitForCompletion();
        SceneManager.LoadScene("Main");
        Destroy(GameSystem.instance.levelSetup);
        Destroy(BlackScreen.instance.gameObject);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
