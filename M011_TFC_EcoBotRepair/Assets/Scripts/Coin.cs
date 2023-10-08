using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Coin : MonoBehaviour
{
    private int valor = 1;
    //public AudioClip coinSFX;

    

    private bool alreadyCalled = false;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Pickable == true && alreadyCalled == false)
        {
            
            GameManager.Instance.SumarPuntosMetal(valor);
            alreadyCalled = true;
            Destroy(this.gameObject); 
            
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }

    

    

}