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

        //Recogemos donde esta
    private float pisicionX;

        //Recogemos valor
    public new UnityEngine.Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pisicionX = transform.position.x;   //Almacenamos donde se encuentra x
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
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);    //Se queda en el sitio
        }

        //Mantenemos las posicones y rotaciones para que no se gire y no se mueva del punto x
        transform.position = new Vector2(pisicionX, rb2D.position.y);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
