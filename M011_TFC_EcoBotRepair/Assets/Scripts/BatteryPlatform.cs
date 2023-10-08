using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPlatform : MonoBehaviour
{
    
    private bool alredyCalled = false;
    

    

    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Battery"))
        {

            if(!alredyCalled)
            {
                LevelManager.Instance.SetBattery();
                alredyCalled = true;

            }

            
            
            
            
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }

     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery"))
        {

            
                alredyCalled = false;

            

            
            
            
            
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }

}
