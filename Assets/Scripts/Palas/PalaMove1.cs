using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaMove1 : MonoBehaviour
{

    //Atributos
        //Variable de movimiento arriba/abajo
    public float speedMove = 5f;

        //Variable de posicion actual
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) //Si pusla la A
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, speedMove);    //Vamos arriba
        }
        else if (Input.GetKey(KeyCode.D))   //Si pulsa la D
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -speedMove);   //Vamos abajo
        }
        else    //Sino
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);    //Se queda en el sitio
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Pared1"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);

            // Marcar el l�mite (puedes agregar tu l�gica personalizada aqu�)
            // Por ejemplo, puedes enviar un mensaje a otro script para manejar la puntuaci�n o el l�mite alcanzado.
        }
    }
}
