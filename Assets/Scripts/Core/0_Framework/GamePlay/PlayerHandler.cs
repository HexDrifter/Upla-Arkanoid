using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UplaArk.InterfaceAdapters;
using UplaArk.Domain;
using UplaArk.Entities;

namespace UplaArk.Framework
{
    public class PlayerHandler
    {
        public Player player;

        public PlayerHandler()
        {
            player = new Player();
        }

        public PlayerHandler(int initialLives)
        {
            player = new Player(initialLives);
        }

        public void AddScore(int scoreValue)
        {

            player.AddScore(scoreValue);
            ServiceLocator.Instance.GetService<SetScore>().SetScoreValue(player.score);
        }
        public void SubstractLife()
        {
            player.SubstractLife();
            ServiceLocator.Instance.GetService<SetLives>().SetLiveValue(player.lives);
        }
        public void EndGame()
        {
            SceneManager.LoadScene("GameOver");
        }
        public int GetLives()
        {
            return player.lives;
        }
    }
}
