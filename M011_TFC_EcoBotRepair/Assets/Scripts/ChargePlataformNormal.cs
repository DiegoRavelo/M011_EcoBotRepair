using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlataformNormal : MonoBehaviour
{
    // Start is called before the first frame update
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

          if (TiempoEnPlataforma >= 1f && PlataformaUsada == false && GameManager.Instance.NivelDeCarga < NivelDeCargaMaximo )
        {
            GameManager.Instance.AumentarNivelDeCarga();

            


            TiempoEnPlataforma = 0f;

            if( NivelDeCargaMaximo >= 3)
            {
                GameManager.Instance.EstablecerCooldown();
            }

            
        }

        
    }

    public int NivelDeCargaMaximo;


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
