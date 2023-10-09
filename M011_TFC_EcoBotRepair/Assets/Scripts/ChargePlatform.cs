using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int NivelDeCargaMaximo;

    public int numeroPlatBateria;

    // Update is called once per frame
    void Update()
    {
        if(PersonajeEnPlataforma == true && PlataformaUsada == false)
        {
            TiempoEnPlataforma += Time.deltaTime;
        }

          if (TiempoEnPlataforma >= 1f && PlataformaUsada == false && GameManager.Instance.NivelDeCarga < NivelDeCargaMaximo && LevelManager.Instance.GetBattery(numeroPlatBateria - 1) == true)
        {
            GameManager.Instance.AumentarNivelDeCarga();

            
            
            PlataformaUsada = true;

            TiempoEnPlataforma = 0f;

             if( NivelDeCargaMaximo >= 3)
            {
                GameManager.Instance.EstablecerCooldown();
            }


            
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
