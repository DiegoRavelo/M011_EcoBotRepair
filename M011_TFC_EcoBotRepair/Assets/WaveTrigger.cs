using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    // Start is called before the first frame update
     public static WaveTrigger Instance {get; private set;}

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }else 
        {
            Destroy(this);
        }
        
        //StartCoroutine("StartSpawing");
        
    }

   

    public Transform[] spawnPoints;

    public GameObject enemy;

    public GameObject enemyFeralla;
   

    public IEnumerator WaveSpawner(WaveInf waves)
    {

        for(int w = 0; w < waves.waveTimes; w++)
        {
            
           for (int i = 0; i < waves.ordenSpawn.Length; i++)
            {
                if(waves.ordenSpawn[i] == 1)
                {
                   print("spawneando bicho" + " en el lugar" + i );

                   enemyInstance(enemy, spawnPoints[i]);

                }

               
                // if (waves.ordenSpawn[i] > 1)
                // {
                //     StartCoroutine(enemyInstanceTimer(waves.ordenSpawn[i], enemyFeralla, spawnPoints[i]));

                //     print("iniciando corutina");
                    
                // }



                
                
            }

             yield return new WaitForSeconds(5f);

      

        }

        enemyInstance(enemyFeralla , spawnPoints[2]);
        enemyInstance(enemyFeralla , spawnPoints[4]);

        yield return new WaitForSeconds(5f);

       BossManager.Instance.CambiarEstado();
        

    }


    public void enemyInstance(GameObject enemy, Transform spawnPoints)
    {
        Instantiate(enemy, spawnPoints.position, spawnPoints.rotation);

    }

    public IEnumerator enemyInstanceTimer(int times, GameObject enemyFeralla, Transform spawnPoints)
    {
        for(int i = 0; i < times; i++)
        {
            Instantiate(enemyFeralla, spawnPoints.position, spawnPoints.rotation);

            yield return new WaitForSeconds(2f);
            

        }
    }
}
