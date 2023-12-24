using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlataformNormal : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    public ParticleSystem[] sp;

     public int[] rate;
    

    void Start()
    {
          for( int i = 0; i < sp.Length; i++)
        {
            sp[i].Pause();
           

           
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PersonajeEnPlataforma == true && PlataformaUsada == false)
        {
            TiempoEnPlataforma += Time.deltaTime;
        }

          if (TiempoEnPlataforma >= 3f && PlataformaUsada == false && GameManager.Instance.NivelDeCarga < NivelDeCargaMaximo )
        {

            GameManager.Instance.AumentarNivelDeCarga();

            


            TiempoEnPlataforma = 0f;

            // if( NivelDeCargaMaximo >= 3)
            // {
            //     GameManager.Instance.EstablecerCooldown();
            // }

            
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
            int nivel = GameManager.Instance.NivelDeCarga;
            
            PersonajeEnPlataforma = true;

            if(nivel < NivelDeCargaMaximo)
            {

                 sp[0].Play();
                 sp[1].Play();
                  sp[2].Play();
         

                 var em1 = sp[0].emission;
                 var em2 = sp[1].emission;
                 var em3 = sp[2].emission;
        

    
                 em1.rateOverTime = rate[0];
                 em2.rateOverTime = rate[1];
                  em3.rateOverTime = rate[2];

                 anim.Play("Carga");

            }

        


        }

        

    }

       private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PersonajeEnPlataforma = false;
            TiempoEnPlataforma = 0f; // Restablece el tiempo cuando el personaje sale de la plataforma
            PlataformaUsada = false;

             var em1 = sp[0].emission;
             var em2 = sp[1].emission;
             var em3 = sp[2].emission;

            em1.rateOverTime = 0f;
            em2.rateOverTime = 0f;
            em3.rateOverTime = 0f;

             anim.Play("Descarga");
        }
    }
}
