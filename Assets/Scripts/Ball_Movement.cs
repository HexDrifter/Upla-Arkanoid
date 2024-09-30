using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
    private Rigidbody2D rbody;
    [SerializeField]    public float speed = 5f;
    [SerializeField]    public float speedUp = 0.3f;
    [SerializeField]    public float altura = 1f;
    bool isMoving = false;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        //la variable apunta al componente
        
    }

    void Update()
    {
        if (!isMoving)
        {
            ubicarEnBarra();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lanzar();
            }
        }

    }

    void ubicarEnBarra()
    {
        var barra = FindObjectOfType<Bar_Movement>();
        var posBarra = barra.transform.position;
        posBarra.y = barra.transform.position.y + altura;
        transform.position = posBarra;
    }

    void lanzar()
    {
        var dirball = new Vector2(-1, 1);
        rbody.velocity = dirball.normalized * speed;
        isMoving = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var contacto = collision.GetContact(0);
        rbody.velocity = Vector2.Reflect(rbody.velocity, contacto.normal) * speedUp;
        //Debug.Log(rbody.velocity);

    }

    private void OnTriggerEnter2D()
    {
        isMoving = false;
        GameManager.instance.player.LostLive();
        
    }

    public void stopBall()
    {
        isMoving = false;
    }
}
