using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
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

        player = new Player(lives);
        var playerViewModel = new PlayerViewModel(player.score, player.lives);
        var playerPresenter = new PlayerPresenter(playerViewModel);
        var setScoreUseCase = new SetScoreUseCase(playerPresenter);
        _playerUIView.SetModel(playerViewModel);

        ServiceLocator.Instance.RegisterService<SetScoreUseCase>(setScoreUseCase);

        var setLivesUseCase = new SetLivesUseCase(playerPresenter);
        ServiceLocator.Instance.RegisterService<SetLivesUseCase>(setLivesUseCase);
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
        player.AddScore(score);

    }

    public void AddBlock(GameObject block)
    {
        blocksList.Add(block.gameObject);
    }

    public void restarBloque(GameObject block)
    {
        blocksList.Remove(block.gameObject);
        if (blocksList.Count <= 0)
        {
            SceneManager.LoadScene(GameManager.instance.nextLevel);
        }
    }

}
