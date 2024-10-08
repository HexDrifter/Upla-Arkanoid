using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UplaArk.InterfaceAdapters;
using UplaArk.Framework;
using UplaArk.Domain;
using DG.Tweening;

public class LevelSetup : MonoBehaviour
{
    public PlayerHandler playerHandler;
    public List<GameObject> blocksList;
    public string nextLevel;
    public bool Reset;
    [SerializeField] private PlayerUIView _playerUIView;
    private void Start()
    {

        if (_playerUIView == null)
        {
            _playerUIView = GameObject.FindGameObjectWithTag("HUD").GetComponent<PlayerUIView>();
        }

        var playerViewModel = new PlayerViewModel(playerHandler.player.score, playerHandler.player.lives);
        var playerPresenter = new PlayerPresenter(playerViewModel);
        var setScoreUseCase = new SetScoreUseCase(playerPresenter);
        _playerUIView.SetModel(playerViewModel);
        ServiceLocator.Instance.RegisterService<SetScore>(setScoreUseCase);
        _playerUIView.SetModel(playerViewModel);
        var setLivesUseCase = new SetLivesUseCase(playerPresenter);
        ServiceLocator.Instance.RegisterService<SetLives>(setLivesUseCase);

        
    }

    public void SetPlayerHandler(PlayerHandler playerHandler)
    {
        this.playerHandler = playerHandler;
    }

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
            
            StartCoroutine(EndLevel());
            
        }
    }
    IEnumerator EndLevel()
    {
        ServiceLocator.Instance.RemoveService<SetScore>();
        ServiceLocator.Instance.RemoveService<SetLives>();
        yield return BlackScreen.instance.FadeIn().WaitForCompletion();
        SceneManager.LoadScene(GameSystem.instance.levelSetup.nextLevel);
    }
 }
