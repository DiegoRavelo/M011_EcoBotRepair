using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutinas : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator sprint;
    void Start()
    {
        sprint = Contar();

        tiempoRestante = 5f;
        //StartCoroutine(sprint);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("empiezo a sprintar");
            startTime = Time.time;
            StartCoroutine(sprint);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Paro de sprintar");
            StopCoroutine(sprint);
            float tiempoTranscurrido = Time.time - startTime;
            tiempoRestante -= tiempoTranscurrido;

        }

        print(tiempoRestante);


        tiempo += Time.deltaTime;

        //print(tiempo);


        //print(startTime);



    }

    private float tiempo = 0f;
    private float tiempoRestante;

    private float startTime;

    //private bool contando = true;

    IEnumerator Contar()
    {

        yield return new WaitForSeconds(tiempoRestante);
        print("Te has quedado sin sprint ");
    }


}
