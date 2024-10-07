using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Blockbehavior : MonoBehaviour
{
    
    public int score = 10;
    public BeepMachine beepMachine;


    private void Start()
    {
        GameSetup.instance.AddBlock(this.gameObject);
    }

    private void OnCollisionEnter2D()
    {
        //Al golpear el bloque se destruye, se resta el contador
        //de bloques y se suma la puntuación
        beepMachine.playBeep();
        GameSetup.instance.addScore(score);
        GameSetup.instance.SubstractBlock(this.gameObject);

        Destroy(gameObject);
    }
}
