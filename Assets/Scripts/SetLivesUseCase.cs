using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLivesUseCase : SetLives
{
    private readonly PlayerLivesOutput _playerLivesOutput;

    public SetLivesUseCase(PlayerLivesOutput output)
    {
        _playerLivesOutput = output;
    }

    public void SetLiveValue(int value)
    {
        _playerLivesOutput.ShowLives(value);
    }
}
