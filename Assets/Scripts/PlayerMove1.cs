using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //Variables
        //Valores de velocidad
    public float runSpeed = 5f; 

        //Referencia al personaje
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()    //Al empezar
    {
        rb2D = GetComponent<Rigidbody2D>(); //Recogemos el valor del personaje rb2D
    }

    // Update is called once per frame
    void Update()   //Se llama cada llamada del frame
    {
        //Movimiento del personaje de izquierda a derecha
        if (Input.GetKey(KeyCode.D))    //Movimiento de derecha
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A)) //Movimiento de izquierda
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }

        //Movimiento de personaje de arriba a abajo
        if (Input.GetKey(KeyCode.W))   //Movimiento acia arriba 
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, runSpeed);
        }
        else if (Input.GetKey(KeyCode.S))    //Movimiento acia abajo
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -runSpeed);
        }

    }

}
