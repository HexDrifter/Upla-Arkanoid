using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string nextLevel = "";
    void Start()
    {
        GameManager.instance.nextLevel = nextLevel;
    }
}