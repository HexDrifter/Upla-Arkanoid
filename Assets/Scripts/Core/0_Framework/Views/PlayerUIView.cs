using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UplaArk.InterfaceAdapters;
using UplaArk.Domain;

namespace UplaArk.Framework
{
    public class PlayerUIView : BaseReactiveView
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _liveText;

        private PlayerViewModel _playerViewModel;

        public void SetModel(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;

            _playerViewModel
                .Score
                .Subscribe((score) =>
                {
                    _scoreText.text = "Score: " + score.ToString();
                })
                .AddTo(_disposables);
            _playerViewModel
                .Lives
                .Subscribe((lives) =>
                {
                    _liveText.text = "Lives: " + lives.ToString();
                })
                .AddTo(_disposables);
        }
    }
}
