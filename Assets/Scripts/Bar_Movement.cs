using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Movement : MonoBehaviour
{
    //código que se encarga de mover la barra(jugador)

    Vector2 moveBar;//variable tipo vector 2, posee las coordenadas x e y
    [SerializeField] public float defaultSpeed = 0.02f; //velocidad de desplazamiento
    [SerializeField] public float slowSpeed = 0.01f;
    [SerializeField] public float fastSpeed = 0.03f;
    [SerializeField] public float moveLimit = 7f;//tamaño del espacio de desplazamiento
    void Start()
    {
        moveBar.y = transform.position.y;
    }

    void Update()
    {
        float speed;
        if (Input.GetKey(KeyCode.C))
        {
            speed = slowSpeed;
        }
        else
        {
            speed = fastSpeed;
        }
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
