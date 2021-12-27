using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Movement : MonoBehaviour
{
    //c�digo que se encarga de mover la barra(jugador)

    Vector2 moveBar;//variable tipo vector 2, posee las coordenadas x e y
    [SerializeField] public float speed = 0.02f; //velocidad de desplazamiento
    [SerializeField] public float moveLimit = 7f;//tama�o del espacio de desplazamiento
    void Start()
    {
        moveBar.y = transform.position.y;
    }

    void Update()
    {
        //Variable movebar guardar� el valor de la posici�n
        //posici�n + (velocidad * valor del input)
        moveBar.x = (transform.position.x + speed * Input.GetAxisRaw("Horizontal"));

        
        if (moveBar.x > moveLimit)
        {
            moveBar.x = moveLimit;
        }
        else if (moveBar.x < -moveLimit)
        {
            moveBar.x = -moveLimit;
        }

        transform.position = moveBar;
        //La posici�n del objeto ser� igual al valor de la variable moveBar

    }



}
