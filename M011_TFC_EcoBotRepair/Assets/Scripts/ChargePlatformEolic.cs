using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlatformEolic : MonoBehaviour
{
    public int plataformaNumero;

    public int nivelMaximoCarga;


     public Animator anim;

    public ParticleSystem[] sp;

      public int[] rate;



    void Start()
    {

        ColorChangCall.OnEnergyChange += HandleActivateParticles;
       

         var em1 = sp[0].emission;
        var em2 = sp[1].emission;
         var em3 = sp[2].emission;
    
        em1.rateOverTime = 0f;
        em2.rateOverTime = 0f;
        em3.rateOverTime = 0f;



    }

    private void OnEnable()
    {

        

        
       

    }

      private void OnDisable()
    {
        // Asegúrate de desuscribirte cuando el objeto se destruye para evitar pérdida de memoria.

       
    }


    // Update is called once per frame
    void Update()
    {
        if (PersonajeEnPlataforma == true && PlataformaUsada == false && LevelManager.Instance.GetTower(plataformaNumero - 1) == true&& cableNumero == plataformaNumero)
        {
            TiempoEnPlataforma += Time.deltaTime;

            if (TiempoEnPlataforma >= 2f && PlataformaUsada == false && GameManager.Instance.NivelDeCarga < nivelMaximoCarga && cableNumero == plataformaNumero )
            {
                GameManager.Instance.AumentarNivelDeCarga();

                

                TiempoEnPlataforma = 0f;

               if( GameManager.Instance.NivelDeCarga >= 3)
                 {
                GameManager.Instance.EstablecerCooldown();
                }



            }
        }

        if(cableNumero == plataformaNumero && LevelManager.Instance.GetTower(plataformaNumero - 1) )
        {
            cableReparado = true;

                var em1 = sp[0].emission;
                var em2 = sp[1].emission;
                var em3 = sp[2].emission;
        

    
                em1.rateOverTime = rate[0];
                em2.rateOverTime = rate[1];
                em3.rateOverTime = rate[2];

        }




    }

    private int cableNumero;

    private bool cableReparado = false;

    private void HandleActivateParticles(int tower, bool isActive)
    {

        if(plataformaNumero == tower)
        {
            cableNumero = tower;

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


              int nivel = GameManager.Instance.NivelDeCarga;
            
            

            if(nivel < nivelMaximoCarga && LevelManager.Instance.GetTower(plataformaNumero - 1) && cableNumero == plataformaNumero)
            {


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

            if(LevelManager.Instance.GetTower(plataformaNumero - 1) && cableNumero == plataformaNumero )
            {
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
}
