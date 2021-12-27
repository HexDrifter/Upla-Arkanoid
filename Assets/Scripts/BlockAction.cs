using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAction : MonoBehaviour
{
    
    public int score = 10;

    private void Start()
    {
        GameManager.instance.sumarBloque();
        //se suma el bloque al contador de bloques
    }

    private void OnCollisionEnter2D()
    {
        //Al golpear el bloque se destruye, se resta el contador
        //de bloques y se suma la puntuación
        Destroy(gameObject);
        GameManager.instance.restarBloque();
        GameManager.instance.addScore(score);
        
    }
}
