using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Muelle : MonoBehaviour
{
    private int valor = 1;
    //public AudioClip coinSFX;

   private bool alreadyCalled = false;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Pickable == true && alreadyCalled == false)
        {
            
            GameManager.Instance.SumarPuntosMuelle(valor);
            alreadyCalled = true;
            Destroy(this.gameObject); 
            
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }

    


   


}
