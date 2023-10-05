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

        //Direccion izquierda derecha
    public bool derecha = false;
    public bool izquierda = false;
    
        //Toca arriba o abajo
    public bool arriba = false;
    public bool abajo = false;

        //Salida inicio
    public bool salida;

        //Rigidbody2D
    public Rigidbody2D rb2D;

        //Recogemos valor
    public new UnityEngine.Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (!salida) //Si no ha salido empezamos con su direccion
        {
            Invoke(nameof(Lanzar), 1.75f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pala1"))   //Con la pala de la izquierda
        {
            derecha = true;
            AplicarRebotePala(collision, 1f); // Aplicar rebote hacia la derecha
        }
        else if (collision.collider.CompareTag("Pala2"))  //Con la pala de la derecha
        {
            izquierda = true;
            AplicarRebotePala(collision, -1f); // Aplicar rebote hacia la derecha
        }
        else if (collision.collider.CompareTag("Pared1"))  //Con la pared superior
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -rb2D.velocity.y);
        }
        else if (collision.collider.CompareTag("Pared2"))  //Con la pared inferior
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y);
        }
    }

    private void AplicarRebotePala(Collision2D collision, float direccionX)
    {
        // Obtén el punto de contacto en la pala
        Vector2 puntoDeContacto = collision.collider.ClosestPoint(collision.contacts[0].point);

        // Calcula el ángulo de rebote
        Vector2 direccion = puntoDeContacto - (Vector2)collision.collider.transform.position;
        direccion.Normalize();
        float anguloDeRebote = Mathf.Atan2(direccion.y, direccion.x);

        // Ajusta la velocidad de rebote en función de la posición de impacto
        float velocidadX = 0f;
        float velocidadY = runMove * Mathf.Sin(anguloDeRebote);

        if (derecha)
        {
            velocidadX = runMove * Mathf.Cos(anguloDeRebote) * direccionX;
        }
        if(izquierda)
        {
            velocidadX = runMove * Mathf.Cos(anguloDeRebote);
        }

        // Aplica la nueva velocidad a la pelota
        rb2D.velocity = new Vector2(velocidadX, velocidadY);

        //Limpuamos
        derecha = false;
        izquierda = false;
    }

    private void Lanzar()   //Lanzamos de vueltala pelota
    {
        if (derecha)    //Si es true la derecha
        {
            rb2D.velocity = new Vector2(runMove, rb2D.velocity.y);
            derecha = false;
        }
        if (izquierda) //Si es true la izquierda
        {
            rb2D.velocity = new Vector2(-runMove, rb2D.velocity.y);
            izquierda = false;
        }
    }

    public void PelotaInicio()      //Inidcamos que siempre empieza en 0, lo llamaremos cuando entre gol
    {
        //Inidcamos que siempre empieza en 0
        Vector2 nuevaPosicon = new Vector2(transform.position.x, transform.position.y);
        transform.position = nuevaPosicon;
    }

}
