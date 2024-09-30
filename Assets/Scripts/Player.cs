using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player
{
    private int _score;
    private int _lives;
    public int score => _score;
    public int lives => _lives;

    public Player()
    {
        _score = 0;
        _lives = 3; 
    }

    public Player(int lives)
    {
        _score = 0;
        _lives = lives;
    }

    public int GetScore()
    {
        return _score;
    }
    public int GetLives()
    {
        return _lives;
    }

    public void AddScore(int score)
    {
        _score += score;
        ServiceLocator.Instance.GetService<SetScoreUseCase>().SetScoreValue(_score);
    }
    public void LostLive()
    {
        _lives--;
        ServiceLocator.Instance.GetService<SetLivesUseCase>().SetLiveValue(_lives);
        if (_lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
