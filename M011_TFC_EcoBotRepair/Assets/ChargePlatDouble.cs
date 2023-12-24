using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePlatDouble : MonoBehaviour
{
    
    public int plataformaNumero;

    public int nivelMaximoCarga;


     public Animator anim;

    public ParticleSystem[] sp;

      public int[] rate;

    

    void Start()
    {

       

        var em1 = sp[0].emission;
        var em2 = sp[1].emission;
         var em3 = sp[2].emission;
    
        em1.rateOverTime = 0f;
        em2.rateOverTime = 0f;
        em3.rateOverTime = 0f;



    }



    
    void Update()
    {
       

        if(LevelManager.Instance.GetTower(plataformaNumero - 1) && LevelManager.Instance.GetBattery(plataformaNumero - 1) && LevelManager.Instance.GetCable(plataformaNumero -1) )
        {
            

        
        
            

                var em1 = sp[0].emission;
                var em2 = sp[1].emission;
                var em3 = sp[2].emission;
        

    
                em1.rateOverTime = rate[0];
                em2.rateOverTime = rate[1];
                em3.rateOverTime = rate[2];

        }




    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && LevelManager.Instance.GetTower(plataformaNumero - 1))
        {

            int nivel = GameManager.Instance.NivelDeCarga;
              
            if(nivel < nivelMaximoCarga)
            {

                 anim.Play("Carga");

            }

        }



    }

    public float TiempoEnPlataforma = 0f;

     private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && LevelManager.Instance.GetBattery(plataformaNumero - 1) && LevelManager.Instance.GetCable(plataformaNumero -1) && LevelManager.Instance.GetTower(plataformaNumero - 1))
        {

              

              TiempoEnPlataforma += Time.deltaTime;
                

            if(GameManager.Instance.NivelDeCarga < nivelMaximoCarga && TiempoEnPlataforma >= 2f)
            {
               

                 GameManager.Instance.AumentarNivelDeCarga();

                  TiempoEnPlataforma = 0f;



              
                //   if( GameManager.Instance.NivelDeCarga >= 3)
                //  {
                // GameManager.Instance.EstablecerCooldown();
                // }


                
                    

            }

        }



    }

    private void NivelDeCarga()
    {
          GameManager.Instance.AumentarNivelDeCarga();
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TiempoEnPlataforma = 0f; 
           

            if(LevelManager.Instance.GetTower(plataformaNumero - 1) )
            {
           
             anim.Play("Descarga");

            }

           
        }
    }
}
