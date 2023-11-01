using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPlatform : MonoBehaviour
{

    private bool alredyCalled = false;
    public int NumeroBateria;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {

            if (!alredyCalled)
            {
                //LevelManager.Instance.SetBattery(true);
                LevelManager.Instance.SetBattery(NumeroBateria);
                Debug.Log("Battery placed");
                alredyCalled = true;

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Battery") && alredyCalled == true)
        {


            alredyCalled = false;
            LevelManager.Instance.SetBattery(NumeroBateria);
            Debug.Log(NumeroBateria + "fuera");

            
        }

    }

}
