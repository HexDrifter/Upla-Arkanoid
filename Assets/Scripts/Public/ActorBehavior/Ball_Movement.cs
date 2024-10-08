using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UplaArk.Framework;

public class Ball_Movement : MonoBehaviour
{
    private Rigidbody2D rbody;
    [SerializeField]    public float speed = 5f;
    [SerializeField]    public float speedUp = 0.3f;
    [SerializeField]    public float altura = 1f;
    [SerializeField] public float aditionalScore;
    bool isMoving = false;
    private float _launchDirection = 1f;
    public static Ball_Movement instance;

    void Awake()
    {
        instance = this;
        rbody = GetComponent<Rigidbody2D>();
        //la variable apunta al componente
        
    }

    void Update()
    {
        if (!isMoving)
        {
            SetDirection();
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
        
        var dirball = new Vector2(_launchDirection,1);
        rbody.velocity = dirball.normalized * Random.Range(0.9f,1.1f) * speed;
        isMoving = true;
    }
    private void SetDirection()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _launchDirection = -1f;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _launchDirection = 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var contacto = collision.GetContact(0);
        rbody.velocity = Vector2.Reflect(rbody.velocity, contacto.normal) * speedUp;
        aditionalScore += speedUp;
        if (GameSystem.instance.levelSetup.blocksList.Count <= 0)
        {
            stopBall();
        }
        //Debug.Log(rbody.velocity);

    }
    public int GetScore()
    {
        return (int)aditionalScore;
    }

    private void OnTriggerEnter2D()
    {
        isMoving = false;
        aditionalScore = 0;
        GameSystem.instance.levelSetup.playerHandler.SubstractLife();
        if(GameSystem.instance.playerHandler.GetLives() <= 0)
        {
            StartCoroutine(GameSystem.instance.EndGame());
        }

        
    }
    

    public void stopBall()
    {
        isMoving = false;
    }
}
