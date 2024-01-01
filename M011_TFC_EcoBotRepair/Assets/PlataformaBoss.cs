using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBoss : MonoBehaviour
{

    public Animator anim;

    public ParticleSystem[] sp;

    public int[] rate;

    public PlataformaStatment estadoActual;

    [SerializeField]

    private float tiempoEnPlataforma;

      [SerializeField]

    private bool[] towers;


    



    void Start()
    {
        AeroBoss.TowerStateChanged += TowerHandler;

        CambiarEstado(PlataformaStatment.UnCharged);

    }


    private void TowerHandler(int tower, bool isActive)
    {
        towers[tower -1] = isActive;
        print("tower");
        TowerState();

    }

    private void TowerState()
    {
        if(towers[0] && towers[1])
        {
            CambiarEstado(PlataformaStatment.Charged);
        }

    }

    private void CambiarEstado(PlataformaStatment newState)
    {
       estadoActual = newState;
    }







  


    // Update is called once per frame
    void Update()
    { 
        var em1 = sp[0].emission;
        var em2 = sp[1].emission;
        var em3 = sp[2].emission;
       
       

        switch(estadoActual)
        {
            case PlataformaStatment.UnCharged:

               
    
               em1.rateOverTime = 0f;
               em2.rateOverTime = 0f;
               em3.rateOverTime = 0f;

            break;

            case PlataformaStatment.Charged:
    
               em1.rateOverTime = 100f;
               em2.rateOverTime = 100f;
               em3.rateOverTime = 100f;
               
            break;

            case PlataformaStatment.CharacterOutsidePlatform:

            tiempoEnPlataforma = 0f;


            break;

            case PlataformaStatment.CharacterOnPlatform:

            tiempoEnPlataforma += Time.deltaTime;

              if(tiempoEnPlataforma >= 4f)
              {
                GameManager.Instance.AumentarNivelDeCarga();
                GameManager.Instance.AumentarNivelDeCarga();
                GameManager.Instance.AumentarNivelDeCarga();

                CambiarEstado(PlataformaStatment.Waiting);
                
              }

            break;

            case PlataformaStatment.Waiting:

            break;


        }


    }

    


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && estadoActual != PlataformaStatment.UnCharged )
        {
            CambiarEstado(PlataformaStatment.CharacterOnPlatform);

              anim.Play("Carga");

          
        }



    }

    //    var em1 = sp[0].emission;
    //    var em2 = sp[1].emission;
    //    var em3 = sp[2].emission;

    //    em1.rateOverTime = 0f;
    //    em2.rateOverTime = 0f;
    //    em3.rateOverTime = 0f;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && estadoActual != PlataformaStatment.UnCharged)
        {
            CambiarEstado(PlataformaStatment.CharacterOutsidePlatform);

              anim.Play("Descarga");
            
        }
    }
}

public enum PlataformaStatment
{
    UnCharged,
    Charged,
    CharacterOutsidePlatform,
    CharacterOnPlatform,
    Waiting
}
