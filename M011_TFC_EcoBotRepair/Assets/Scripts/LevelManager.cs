using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public static LevelManager Instance { get; private set; }

     public bool battery_1;


     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un LevelManager en escena.");
        }


    }

    public void SetBattery()
    {
        battery_1 = true;
        Debug.Log("Bateria en su sitio");

    }

    public bool Battery_1
    {
        get { return battery_1; }
        private set { battery_1 = value; } 
    }




    
}
