using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonAct : MonoBehaviour
{
    //Este script le da función a los botones iniciar juego y volver al menu principal
    public void OnClickStartNewGameButton()
    {
        SceneManager.LoadScene("Level1");
        if (GameSetup.instance != null)
        {
            GameSetup.instance.playerHandler = new UplaArk.Framework.PlayerHandler();
        }
    }
    public void OnClickBackMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameSetup.instance);
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
