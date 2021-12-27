using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    //Script para escribir el nombre del nivel siguiente
    public string nextLevel = "";
    void Start()
    {
        GameManager.instance.nextLevel = nextLevel;
    }

}
