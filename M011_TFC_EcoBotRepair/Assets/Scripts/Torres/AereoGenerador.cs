using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class AereoGenerador : MonoBehaviour
{
    // Start is called before the first frame update
  public Animator animator;
    public int MuelleReparar;
    public int TuercaReparar;
    public int MetalReparar;
    public bool reparando;
    public float tiempoReparando;
    public int TorreNumero;
    public Animator sliderAnim;
    public bool torreReparada = false;

    
    public Image[] imageComponent;
    
    public UnityEngine.Sprite[] tilesCon;

    public Animator[] TowerPop;
    
    

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera OriginalvirtualCamera;

    void Start()
    {
        LevelManager.TowerStateChanged += HandleCameraTransition;

        //virtualCamera.OnTargetObjectWarped += HandleCameraWarped;

        
            imageComponent[0].sprite = tilesCon[MuelleReparar];

            imageComponent[1].sprite = tilesCon[TuercaReparar];

            imageComponent[2].sprite = tilesCon[MetalReparar];


            // for (int i = 0; i < imageComponent.Length; i++)
            //  {
            //     imageComponent[i].rectTransform.sizeDelta = Vector3.zero;

            // }
           
           
        
    
    }

     private void OnDisable()
    {
        
        LevelManager.TowerStateChanged -= HandleCameraTransition;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
    {
        // Almacenar la instancia del GameManager para evitar repetir GameManager.Instance
        GameManager gameManager = GameManager.Instance;

        if (gameManager.Reparando && gameManager.MetalTotal >= MetalReparar &&
            gameManager.MuelleTotal >= MuelleReparar && gameManager.TuercaTotal >= TuercaReparar &&
            gameManager.NivelDeCarga >= 1)
        {
            // Si el jugador está reparando y cumple con las condiciones, iniciar la reparación
            reparando = true;
            sliderAnim.Play("Reparando");
        }
        else if (!gameManager.Reparando)
        {
            // Si el jugador no está reparando, detener la reparación
            reparando = false;
            tiempoReparando = 0f;
            sliderAnim.Play("Idle");
        }

        if (torreReparada)
        {
            // Si la torre ya está reparada, reproducir la animación "Idle"
            sliderAnim.Play("Idle");
        }
    }
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && torreReparada == false)
        {
            
              for (int i = 0; i < TowerPop.Length; i++)
            {
                TowerPop[i].Play("TowerPop");
                

            }

            // TowerPop[0].Play("TowerPop");
            // TowerPop[1].Play("TowerPop");
            // TowerPop[2].Play("TowerPop");

            
             
        }

    }

  
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && torreReparada == false)
        {
            reparando = false;
            tiempoReparando = 0f;
            sliderAnim.Play("Idle");

            

 
              for (int i = 0; i < TowerPop.Length; i++)
            {
                TowerPop[i].Play("TowerPop2");

            }
           
        
        }
    }

    void Update()
    {
        if(LevelManager.Instance.GetTower(TorreNumero - 1) == true)
        {
             animator.SetBool("Reparado", true);
             
        }

        if (reparando)
        {
            tiempoReparando += Time.deltaTime;
            

            
        }

        if (tiempoReparando >= 4f && torreReparada == false)
            {
                LevelManager.Instance.SetTower(TorreNumero);

                print("torre reparada");
                
                torreReparada = true;
                animator.SetBool("Reparado", true);

                GameManager.Instance.DisminuirNivelDeCarga();
                tiempoReparando = 0f;

                

                GameManager.Instance.SumarPuntosMetal(-MetalReparar);
                GameManager.Instance.SumarPuntosTuerca(-TuercaReparar);
                GameManager.Instance.SumarPuntosMuelle(-MuelleReparar);

                Debug.Log("Torre " + TorreNumero + " reparada");
                
            }

        

 
    }

    private void HandleCameraTransition(int tower, bool isActive)
    {
        print("hola");
          
              for (int i = 0; i < TowerPop.Length; i++)
            {
                TowerPop[i].Play("TowerPop2");

            }

        if(tower == TorreNumero)
        {
            virtualCamera.Priority = OriginalvirtualCamera.Priority + 1 ;

            Invoke("HandleCameraRetrun", 4f);

        }


    }

    private void HandleCameraRetrun()
    {
        virtualCamera.Priority = OriginalvirtualCamera.Priority - 1 ;

        //OriginalvirtualCamera.Priority = 11;

    }

    

}
