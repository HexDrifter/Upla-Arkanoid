using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UplaArk.Domain;
using UplaArk.Framework;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] public TMP_Text currentScoreText;
    [SerializeField] public TMP_Text maxScoreText;
    public int currentScore;
    private void Start()
    {
        StartCoroutine(BlackScreen.instance.FadeOut());
        Debug.Log("Inicia escena");
        currentScore = GameSystem.instance.playerHandler.player.score;

        if (GameSystem.instance.maxScore < currentScore)
        {
            GameSystem.instance.maxScore = currentScore;
            maxScoreText.text = "Nuevo Record: " + GameSystem.instance.maxScore;
        }
        else
        {
            maxScoreText.text = "Máxima puntuación: " + GameSystem.instance.maxScore;
        }
        currentScoreText.text = "Tu puntuación: " + currentScore;

        ServiceLocator.Instance.RemoveService<SetScore>();
        ServiceLocator.Instance.RemoveService<SetLives>();
    }


}
