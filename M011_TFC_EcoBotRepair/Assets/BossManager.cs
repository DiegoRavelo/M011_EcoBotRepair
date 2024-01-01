using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;


public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BossManager Instance {get; private set;}

    public BossStatement estadoActual;

    public Dialogue[] dialogueBoss;

    public WaveInf[] waves;

    public CinemachineVirtualCamera virtualCamera;

    public CinemachineVirtualCamera OriginalvirtualCamera;

    
    public CinemachineVirtualCamera WaveCamera;

    public Queue<BossStatement> colaBossStatements;



    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }else 
        {
            Destroy(this);
        }

        colaBossStatements = new Queue<BossStatement>();

        colaBossStatements.Enqueue(BossStatement.Talk1);

        colaBossStatements.Enqueue(BossStatement.Wave1);

        colaBossStatements.Enqueue(BossStatement.Talk2);

         colaBossStatements.Enqueue(BossStatement.Repair1);

        colaBossStatements.Enqueue(BossStatement.Wave2);

        colaBossStatements.Enqueue(BossStatement.Talk3);

        colaBossStatements.Enqueue(BossStatement.Wave3);

        estadoActual = BossStatement.IdleWaiting;

        
    }

    public void CambiarEstado()
    {
        colaBossStatements.Dequeue();

        estadoActual = colaBossStatements.Peek();

            
    }

    public void IniciarBoss()
    {
        estadoActual = BossStatement.Talk1;
    }

    private void CambiarPorNum()
    {
        estadoActual = BossStatement.IdleWaiting;
        
    }

  



    // public BossStatement NextStatment()
    // {
    //     return;
    // }

    void Update()
    {
        print(estadoActual);

        print(colaBossStatements.Peek());
    
        

        switch(estadoActual)
        {
            case BossStatement.Wave1:

            StartCoroutine(WaveTrigger.Instance.WaveSpawner(waves[0]));

            OriginalvirtualCamera.Priority = virtualCamera.Priority + 1; 

            WaveCamera.Priority = OriginalvirtualCamera.Priority + 1;

            print("juannn");

            CambiarPorNum();

            break;

            case BossStatement.Repair1:

            OriginalvirtualCamera.Priority = virtualCamera.Priority + 1;


            break;

            case BossStatement.Wave2:

            break;

            case BossStatement.Wave3:

            break;

            case BossStatement.Talk1:

            print(estadoActual);

            virtualCamera.Priority = OriginalvirtualCamera.Priority + 1;

            DialogueManagerBoss.Instance.StartDialogueBoss(dialogueBoss[0]);

            CambiarPorNum();


            break;

            case BossStatement.Talk2:

            print(estadoActual);

            virtualCamera.Priority = OriginalvirtualCamera.Priority + 1;

            DialogueManagerBoss.Instance.StartDialogueBoss(dialogueBoss[1]);
            
            CambiarPorNum();

            break;

              case BossStatement.Talk3:

            break;

            case BossStatement.IdleWaiting:

           

            break;


        }
    }



    
}

    public enum BossStatement
{
    IdleWaiting,
    Wave1,
    Wave2,
    Wave3,
    PostWave1,
    PostWave2,
    PostWave3,
    Repair1,
    Repair2,
    Repair3,
    Talk1,
    Talk2, 
    Talk3
}
