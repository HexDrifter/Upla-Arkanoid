using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UplaArk.Domain
{

    public class SetScoreUseCase : SetScore
    {
        private readonly PlayerScoreOutput _scoreOutput;

        public SetScoreUseCase(PlayerScoreOutput output)
        {
            _scoreOutput = output;
        }

        public void SetScoreValue(int value)
        {
            _scoreOutput.ShowScore(value);

        }
    }

}