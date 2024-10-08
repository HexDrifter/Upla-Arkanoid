using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UplaArk.Framework;

public class GameSystem : MonoBehaviour

{
    public static GameSystem instance;
    public PlayerHandler playerHandler;
    public int maxScore;
    public int lives;

    public LevelSetup levelSetup = null;
    private void Awake()
    {
        DontDestroy();
        Singleton();

        playerHandler = new PlayerHandler(lives);

    }

    public IEnumerator EndGame()
    {
        yield return BlackScreen.instance.FadeIn().WaitForCompletion();
        playerHandler.EndGame();
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
        levelSetup = null;
        try
        {
            levelSetup = GameObject.Find("LevelSetup").GetComponent<LevelSetup>();
        }
        catch { }
        
        if (levelSetup != null)
        {
            Debug.Log("Objeto encontrado");
            if (levelSetup.Reset)
            {
                playerHandler = new PlayerHandler(lives);
            }
            levelSetup.SetPlayerHandler(playerHandler);
            StartCoroutine(BlackScreen.instance.FadeOut());
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
