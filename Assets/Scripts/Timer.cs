using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Attributos
        //Atributos de texto
    public Text isOver;
    public Text timeText;   //Referencia al objeto Texto

        //Atributos numericos
    public float inicialTime = 0f;  //El tiempo inicial
    
    // Update is called once per frame
    void Update()
    {
        CuentaAtras();  //Llamamos al metodo por cada frame
    }

    /*
        Metodo que va a ir restando segundo a segundo a segundo el tiempo que indicamos en inicialTime y si ha acabado el tiempo se mostrara x texto
        en el isOver
     */
    public void CuentaAtras()
    {
        inicialTime -= Time.deltaTime;      //Usamos deltaTime que es el tiempo real
        timeText.text = "" + inicialTime.ToString("f0");    //Lo pasamos a string el inicialTime sin decimales

        if(inicialTime < 0f)    //Cuando este sea menor que 0 entrara
        {
            Time.timeScale = 0f;    //Esto nos permite pausar el juego
            isOver.gameObject.SetActive(true);  //Mostramos el texto
        }
    }
}
