using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class AeroBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public AerobossStatment estadoActual;

    public Animator[] TowerPop;
     
    public Image[] imageComponent;

    public UnityEngine.Sprite[] tilesCon;

    public int MuelleReparar;

    public int TuercaReparar;

    public int MetalReparar;

    private float tiempoReparando;

    private Animator TowerAnim;

    public ParticleSystem[] sp;

     public Animator sliderAnim;

    [SerializeField]

    private int TowerNum;

    public delegate void TowerBossChangeHandler(int tower, bool isActive);

    public static event  TowerBossChangeHandler TowerStateChanged;


    void Start()
    {
          imageComponent[0].sprite = tilesCon[MuelleReparar];

          imageComponent[1].sprite = tilesCon[TuercaReparar];

          imageComponent[2].sprite = tilesCon[MetalReparar];

          TowerAnim = GetComponent<Animator>();


        
    }

    public void CambiarEstado(AerobossStatment newState)
    {
        estadoActual = newState;
    }

    // Update is called once per frame
    void Update()
    {
        switch(estadoActual)
        {
            case AerobossStatment.Broken:

            break;

            case AerobossStatment.CharacterInside:

            if(GameManager.Instance.Reparando)
            {
                CambiarEstado(AerobossStatment.BeingRepaired);

            }

            break;

            case AerobossStatment.BeingRepaired:

              tiempoReparando += Time.deltaTime;

               sliderAnim.Play("Reparando");

              if(tiempoReparando >= 4f)
              {
                CambiarEstado(AerobossStatment.Reapired);

                 sliderAnim.Play("Idle");

              }
              else if(!GameManager.Instance.Reparando)
              {
                CambiarEstado(AerobossStatment.CharacterInside);

                 sliderAnim.Play("Idle");

              }

            break;

            case AerobossStatment.Reapired:

             TowerAnim.SetBool("Reparado", true);

             var em1 = sp[0].emission;
             var em2 = sp[1].emission;  

             em1.rateOverTime = 0f;
             em2.rateOverTime = 0f;

             TowerStateChanged.Invoke(TowerNum, true);

                 for (int i = 0; i < TowerPop.Length; i++)
            {
                
                TowerPop[i].Play("TowerPop2");
                

            }
                

            GameManager.Instance.SumarPuntosMetal(-MetalReparar);
            GameManager.Instance.SumarPuntosTuerca(-TuercaReparar);
            GameManager.Instance.SumarPuntosMuelle(-MuelleReparar);

          
            LevelManager.Instance.SetTower(TowerNum);

            CambiarEstado(AerobossStatment.Idle);

            break;

            case AerobossStatment.Idle:

            print(estadoActual);


            break;

        }
        
    }

    private  void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && estadoActual != AerobossStatment.Reapired)
        {
            CambiarEstado(AerobossStatment.CharacterInside);

              
              for (int i = 0; i < TowerPop.Length; i++)
            {
                
                TowerPop[i].Play("TowerPop");
                

            }

        }
    }

    private  void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && estadoActual != AerobossStatment.Reapired)
        {
            CambiarEstado(AerobossStatment.CharacterOutside);

              
              for (int i = 0; i < TowerPop.Length; i++)
            {
                
                TowerPop[i].Play("TowerPop2");
                

            }

        }
    }
}

public enum AerobossStatment
{
    Broken,
    CharacterInside,
    CharacterOutside,
    BeingRepaired,
    Reapired,
    Idle,
}
