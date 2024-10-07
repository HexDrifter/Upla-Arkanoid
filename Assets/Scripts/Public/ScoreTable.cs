using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] public TMP_Text currentScoreText;
    [SerializeField] public TMP_Text maxScoreText;
    public int maxScore = 0;
    public int currentScore;
    //public ScoreTable instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //Singleton();
    }
    private void Start()
    {
        Debug.Log("Inicia escena");
        currentScore = GameSetup.instance.playerHandler.player.score;
        if (maxScore < currentScore)
        {
            maxScore = currentScore;
            maxScoreText.text = "Nuevo Record: " + maxScore;
        }
        else
        {
            maxScoreText.text = "Máxima puntuación: " + maxScore;
        }
        currentScoreText.text = "Tu puntuación: " + currentScore;

    }

    

}
