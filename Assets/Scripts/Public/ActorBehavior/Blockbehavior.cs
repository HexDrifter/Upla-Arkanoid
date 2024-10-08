using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Blockbehavior : MonoBehaviour
{
    
    public int score = 10;
    public BeepMachine beepMachine;


    private void Start()
    {
        GameSystem.instance.levelSetup.AddBlock(this.gameObject);
    }

    private void OnCollisionEnter2D()
    {
        //Al golpear el bloque se destruye, se resta el contador
        //de bloques y se suma la puntuación
        beepMachine.playBeep();
        GameSystem.instance.levelSetup.addScore(score + Ball_Movement.instance.GetScore());
        GameSystem.instance.levelSetup.SubstractBlock(this.gameObject);

        Destroy(gameObject);
    }
}
