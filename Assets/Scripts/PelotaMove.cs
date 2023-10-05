using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PelotaMove : MonoBehaviour
{
    //Atriburos
        //Velocidad desplazamiento
    public float runMove = 6f; 

        //Direccion inicio
    public bool derecha = false;
    public bool izquierda = false;

        //Salida inicio
    public bool salida;

        //Rigidbody2D
    public Rigidbody2D rb2D;

        //Recogemos valor
    public UnityEngine.Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        salida = false;

        System.Random random = new System.Random();
        int numeroAleatorio = random.Next(2);

        if(numeroAleatorio == 1)    //Si es uno empieza por la derecha
        {
            derecha = true;
        }
        else    //Si es 0 empieza por la izquierda
        {
            izquierda = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!salida) //Si no ha salido empezamos con su direccion
        {
            Invoke(nameof(Lanzar), 1.75f);           
        }
        else   //Si ya esta en movimiento
        {
            Lanzar();   //Re lanzamos
        }
    }

    private void Lanzar()   //Lanzamos de vueltala pelota
    {
        if (derecha)    //Si es true la derecha
        {
            rb2D.velocity = new Vector2(runMove, rb2D.velocity.y);
            derecha = false;
        }
        else if (izquierda) //Si es true la izquierda
        {
            rb2D.velocity = new Vector2(-runMove, rb2D.velocity.y);
            izquierda = false;
        }
    }

    public void PelotaInicio()      //Inidcamos que siempre empieza en 0
    {
            //Inidcamos que siempre empieza en 0
        Vector2 nuevaPosicon = new Vector2(transform.position.x, transform.position.y);
        transform.position = nuevaPosicon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pala1"))
        {
            derecha = true;
        }
        if (collision.CompareTag("Pala2"))
        {
            izquierda = true;
        }

    }

}
