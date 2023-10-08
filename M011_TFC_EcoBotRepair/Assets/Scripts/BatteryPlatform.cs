using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPlatform : MonoBehaviour
{
    
    private bool alredyCalled = false;

    public int NumeroBateria; 


    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Battery"))
        {

            if(!alredyCalled)
            {
                LevelManager.Instance.SetBattery(true);
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
                LevelManager.Instance.SetBattery(false);

            

            
            
            
            
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }

}
