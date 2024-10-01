using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UplaArk.InterfaceAdapters;
using UplaArk.Framework;
using UplaArk.Domain;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerHandler playerHandler;
    public int lives;
    public List<GameObject> blocksList;
    public string nextLevel;
    [SerializeField] private PlayerUIView _playerUIView;
    private void Awake()
    {

        Singleton();        //*Función para tener una sola instancia y
                                //destruir las instancias duplicadas
        DontDestroy();      //*Función para no destruir la instancia durante
                            //cargas de escenas

        playerHandler = new PlayerHandler();
        var playerViewModel = new PlayerViewModel(playerHandler.player.score, playerHandler.player.lives);
        var playerPresenter = new PlayerPresenter(playerViewModel);
        var setScoreUseCase = new SetScoreUseCase(playerPresenter);
        _playerUIView.SetModel(playerViewModel);

        ServiceLocator.Instance.RegisterService<SetScore>(setScoreUseCase);
        _playerUIView.SetModel(playerViewModel);
        var setLivesUseCase = new SetLivesUseCase(playerPresenter);
        ServiceLocator.Instance.RegisterService<SetLives>(setLivesUseCase);

        
    }

    #region singleton
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
        #endregion

    public void addScore(int score)
    {
        playerHandler.AddScore(score);
    }
    public void AddBlock(GameObject block)
    {
        blocksList.Add(block.gameObject);
    }
    public void SubstractBlock(GameObject block)
    {
        blocksList.Remove(block.gameObject);
        if (blocksList.Count <= 0)
        {
                SceneManager.LoadScene(GameManager.instance.nextLevel);
        }
    }
 }
