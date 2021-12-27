using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Ball_Movement ball;
    public int scoreGame;
    public int lives;
    private int vidas;
    public Text textoScore;
    public Text textolives;
    public int cantBloques;
    public string nextLevel;

    
    private void Awake() //C�digo que se carga antes del primer frame
    {
        vidas = lives;      //*El valor de vidas guardar� el valor de lives,
                            //as� siempre tendremos un default
        Singleton();        //*Funci�n para tener una sola instancia y
                            //destruir las instancias duplicadas
        DontDestroy();      //*Funci�n para no destruir la instancia durante
                            //cargas de escenas
        setToDefault();     //*Funci�n para reiniciar los valores de las
                            //variables
    }
    private void Update()
    {
        textoScore.text = ("Score: " + scoreGame);
        textolives.text = ("Vidas: " + lives);


    }

    public void setToDefault()
    {
        lives = vidas;
        scoreGame = 0;
        cantBloques = 0;
    }



    private void DontDestroy()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exist");
            Destroy(this.gameObject);

        }
    }



    

    
    public void addScore(int score)
    {
        scoreGame += score;

    }
    public void lostLive()
    {
        lives -= 1;
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void sumarBloque()
    {
        cantBloques+= 1;
    }
    public void restarBloque()
    {
        cantBloques -= 1;
        if (cantBloques <= 0)
        {
            SceneManager.LoadScene(GameManager.instance.nextLevel);
        }
    }

}
