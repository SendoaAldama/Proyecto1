using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PelotaMove : MonoBehaviour
{
    //Atriburos
        //Velocidad desplazamiento
    public float runMove = 6f; 

        //Direccion izquierda derecha
    private bool derecha = false;
    private bool izquierda = false;

        //Toca arriba o abajo
    private bool arriba = false;
    private bool abajo = false;

        //Salida inicio
    private bool salida;

        //Rigidbody2D
    public Rigidbody2D rb2D;

        //Recogemos valor
    public new UnityEngine.Transform transform;

        //Marcador
    public Text marcador;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Porteria1"))
        {
            // Obtén el texto del componente Text
            string textoCompleto = marcador.text;

            // Separa el texto en un array utilizando la coma como separador
            string[] elementos = textoCompleto.Split(' ');
            elementos[2] = (int.Parse(elementos[2]) + 1).ToString();

            // Une los elementos del array de nuevo en una cadena con comas
            string nuevoTexto = string.Join(" ", elementos);
            marcador.text = nuevoTexto;

            izquierda = true;
            PelotaInicio();
        }
        if (collision.CompareTag("Porteria2"))
        {
            // Obtén el texto del componente Text
            string textoCompleto = marcador.text;

            // Separa el texto en un array utilizando la coma como separador
            string[] elementos = textoCompleto.Split(' ');
            elementos[0] = (int.Parse(elementos[0]) + 1).ToString();

            // Une los elementos del array de nuevo en una cadena con comas
            string nuevoTexto = string.Join(" ", elementos);
            marcador.text = nuevoTexto;

            derecha = true;
            PelotaInicio();
        }
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
            abajo = true;
            if (rb2D.velocity.x > 0)
            {
                derecha = true;
                AplicarReboteTecho(collision, 1f); // Aplicar rebote hacia la derecha
            }
            else if (rb2D.velocity.x < 0)
            {
                izquierda = true;
                AplicarReboteTecho(collision, -1f); // Aplicar rebote hacia la derecha
            }
        }
        else if (collision.collider.CompareTag("Pared2"))  //Con la pared inferior
        {
            arriba = true;
            if (rb2D.velocity.x > 0)
            {
                derecha = true;
                AplicarReboteTecho(collision, 1f); // Aplicar rebote hacia la derecha
            }
            else if (rb2D.velocity.x < 0)
            {
                izquierda = true;
                AplicarReboteTecho(collision, -1f); // Aplicar rebote hacia la derecha
            }
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
        float velocidadX = runMove * Mathf.Cos(anguloDeRebote);
        float velocidadY = runMove * Mathf.Sin(anguloDeRebote);

        // Aplica la nueva velocidad a la pelota
        rb2D.velocity = new Vector2(velocidadX, velocidadY);

        //Limpuamos
        derecha = false;
        izquierda = false;
    }

    private void AplicarReboteTecho(Collision2D collision, float direccionX)
    {
        // Calcula el ángulo de rebote en radianes
        float anguloDeRebote = 0f;

        if (arriba) //Si va hacia arriba
        {
            anguloDeRebote = Mathf.Deg2Rad * 45f; // 45 grados en radianes
        }
        if (abajo)  //Si va hacia abajo
        {
            anguloDeRebote = Mathf.Deg2Rad * -45f; // -45 grados en radianes
        }

        // Calcula la dirección de rebote
        Vector2 direccionDeRebote = new Vector2(Mathf.Cos(anguloDeRebote), Mathf.Sin(anguloDeRebote));

        // Calcula la velocidad de rebote en función del ángulo de rebote y la velocidad de movimiento original
        float velocidadX = runMove * Mathf.Cos(anguloDeRebote) * direccionX;
        float velocidadY = runMove * Mathf.Sin(anguloDeRebote);

        // Aplica la nueva velocidad a la pelota
        rb2D.velocity = new Vector2(velocidadX, velocidadY);

        // Limpia las banderas de dirección
        arriba = false;
        abajo = false;
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

    private void PelotaInicio()      //Inidcamos que siempre empieza en 0, lo llamaremos cuando entre gol
    {
        //Velocidad 0 para que se quede quieto
        rb2D.velocity = new Vector2 (0f, 0f);

        // Asignamos la posición (0, 0) directamente al atributo transform.position
        transform.position = new Vector2(0f, 0f);

        Invoke(nameof(Lanzar), 1.75f);
    }

}
