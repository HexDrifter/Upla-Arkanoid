using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerViewModel
{
    public IntReactiveProperty Score;
    public IntReactiveProperty Lives;

    public PlayerViewModel(int score, int lives)
    {
        Score = new IntReactiveProperty(score);
        Lives = new IntReactiveProperty(lives);
    }
}
