using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour
{
    // Script para reiniciar valores cuando se comienza el nivel 1
    void Awake()
    {
        GameManager.instance.setToDefault();
    }
}
