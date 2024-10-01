using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UplaArk.Entities
{
    public class Player
    {
        public int score;
        public int lives;


        public Player()
        {
            score = 0;
            lives = 3;
        }

        public Player(int liveValue)
        {
            score = 0;
            lives = liveValue;
        }

        public void AddScore(int scoreValue)
        {
            score += scoreValue;
        }
        public void SubstractLife()
        {
            lives--;
        }


    }
}