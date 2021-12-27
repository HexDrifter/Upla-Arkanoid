using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Movement : MonoBehaviour
{
    //código que se encarga de mover la barra(jugador)

    Vector2 moveBar;//variable tipo vector 2, posee las coordenadas x e y
    [SerializeField] public float speed = 0.02f; //velocidad de desplazamiento
    [SerializeField] public float moveLimit = 7f;//tamaño del espacio de desplazamiento
    void Start()
    {
        moveBar.y = transform.position.y;
    }

    void Update()
    {
        //Variable movebar guardará el valor de la posición
        //posición + (velocidad * valor del input)
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
        //La posición del objeto será igual al valor de la variable moveBar

    }



}
