using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{

    //Variables
        //Valores de velocidad
    public float runSpeed = 2f; 

        //Referencia al personaje
    public Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()    //Al empezar
    {
        rb2D = GetComponent<Rigidbody2D>(); //Recogemos el valor del personaje rb2D
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Movimiento del personaje de izquierda a derecha
        if (Input.GetKey(KeyCode.RightArrow))    //Movimiento de derecha
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //Movimiento de izquierda
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
        }
        else  //No hay movimiento
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        //Movimiento de personaje de arriba a abajo
        if (Input.GetKey(KeyCode.UpArrow))   //Movimiento arriba
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, runSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))    //Movimiento abajo
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -runSpeed);
        }

    }

}
