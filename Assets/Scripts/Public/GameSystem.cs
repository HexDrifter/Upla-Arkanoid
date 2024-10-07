using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour

{
    public static GameSystem instance;
    public GameSetup gameSetup = null;
    private void Awake()
    {
        DontDestroy();
        Singleton();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        gameSetup = GameObject.Find("Game Setup").GetComponent<GameSetup>();
        if (gameSetup != null)
        {
            Debug.Log("Objeto encontrado");
        }
        else
        {
            Debug.LogWarning("Objeto no encontrado");
        }



    }

    private void DontDestroy()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exist");
            Destroy(this.gameObject);

        }
    }
}
