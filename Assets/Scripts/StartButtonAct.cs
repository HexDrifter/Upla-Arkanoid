using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonAct : MonoBehaviour
{
    //Este script le da función a los botones iniciar juego y volver al menu principal
    public void OnClicInStartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnClicInBackMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
