using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlatformEolic : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PersonajeEnPlataforma == true && PlataformaUsada == false)
        {
            TiempoEnPlataforma += Time.deltaTime;
        }

          if (TiempoEnPlataforma >= 1f && PlataformaUsada == false && GameManager.Instance.NivelDeCarga <= 2 && LevelManager.Instance.Battery_1 == true)
        {
            GameManager.Instance.AumentarNivelDeCarga();

            GameManager.Instance.EstablecerCooldown();

            
            PlataformaUsada = true;

            TiempoEnPlataforma = 0f;

            
        }

        
    }


    public float TiempoEnPlataforma = 0f;

    public bool PlataformaUsada = false;

    public bool PersonajeEnPlataforma = false;
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlataformaUsada == false)
        {
            
            PersonajeEnPlataforma = true;

        }

        

    }

       private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PersonajeEnPlataforma = false;
            TiempoEnPlataforma = 0f; // Restablece el tiempo cuando el personaje sale de la plataforma
            PlataformaUsada = false;
        }
    }
}
