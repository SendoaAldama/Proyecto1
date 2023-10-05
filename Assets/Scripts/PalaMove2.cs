using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaMove2 : MonoBehaviour
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
        if(Input.GetKey(KeyCode.LeftArrow)) //Si pulsamos la Flecha izquierda
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, speedMove);    //Vamos arriba
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //Si pulsamos la Flecha derecha
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, -speedMove);    //Vamos abajo
        }
        else    //Sino
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);    //Se queda en el sitio
        }
    }
}
