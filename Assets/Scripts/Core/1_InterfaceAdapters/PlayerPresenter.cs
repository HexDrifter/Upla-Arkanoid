using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UplaArk.Domain;

namespace UplaArk.InterfaceAdapters
{
    public class PlayerPresenter : PlayerLivesOutput, PlayerScoreOutput
    {
        private readonly PlayerViewModel _playerViewModel;
        public PlayerPresenter(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }

        public void ShowScore(int score)
        {
            _playerViewModel.Score.Value = score;
        }
        public void ShowLives(int lives)
        {
            _playerViewModel.Lives.Value = lives;
        }

    }
}