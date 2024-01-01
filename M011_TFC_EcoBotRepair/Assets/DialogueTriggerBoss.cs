using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DialogueTriggerBoss : MonoBehaviour
{
    // Start is called before the first frame update


  

  

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
             print("aaaaaaaaaaaaaaaaaaaaa");

            BossManager.Instance.IniciarBoss();

            Destroy(gameObject);           
        }

    }


    
}
