using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UplaArk.InterfaceAdapters;

namespace UplaArk.InterfaceAdapters
{
    public class PlayerViewModel
    {
        public IntReactiveProperty Score;
        public IntReactiveProperty Lives;

        public PlayerViewModel(int initialScore, int initialLives)
        {
            Score = new IntReactiveProperty(initialScore);
            Lives = new IntReactiveProperty(initialLives);
        }
    }
}