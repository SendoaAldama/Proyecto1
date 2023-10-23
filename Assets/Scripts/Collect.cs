using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{

    //Atributos
    public Text texto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }

        int contador = int.Parse(texto.text);
        contador++;
        texto.text = contador.ToString();
    }

}
