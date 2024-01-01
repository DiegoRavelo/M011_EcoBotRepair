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

    public ParticleSystem[] sp;

    public Animator[] TowerPop;

    [SerializeField]

    private AudioClip[] clips;


    private AudioSource audioSource;
    
    

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera OriginalvirtualCamera;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        LevelManager.TowerStateChanged += HandleCameraTransition;

        //virtualCamera.OnTargetObjectWarped += HandleCameraWarped;

        
            imageComponent[0].sprite = tilesCon[MuelleReparar];

            imageComponent[1].sprite = tilesCon[TuercaReparar];

            imageComponent[2].sprite = tilesCon[MetalReparar];


            audioSource.clip = clips[1];

            audioSource.loop = true;

            audioSource.Play();


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

            if(!audioSource.isPlaying)
            {
                audioSource.clip = clips[2];
                audioSource.loop = false;
                  audioSource.Play();
                  

            }

          
        }
        else if (!gameManager.Reparando && torreReparada == false)
        {
            // Si el jugador no está reparando, detener la reparación
            reparando = false;
            tiempoReparando = 0f;
            audioSource.Stop();
            sliderAnim.Play("Idle");

            

           // audioSource.Stop();
        }

        if (torreReparada)
        {
            // Si la torre ya está reparada, reproducir la animación "Idle"
            sliderAnim.Play("Idle");

             var em1 = sp[0].emission;
             var em2 = sp[1].emission;
               
        

    
                em1.rateOverTime = 0f;
                em2.rateOverTime = 0f;
                
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

              audioSource.Stop();

            

 
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

            audioSource.clip = clips[0];

            audioSource.loop = true;

            audioSource.Play();

        }


    }

    private void HandleCameraRetrun()
    {
        virtualCamera.Priority = OriginalvirtualCamera.Priority - 1 ;

        //OriginalvirtualCamera.Priority = 11;

    }

    

}
