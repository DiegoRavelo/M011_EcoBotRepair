using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public bool battery_1;
    public bool eolicTower_1;


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

    private List<bool> torresActivas = new List<bool>();

    private void Start()
    {
        torresActivas.Add(false); // Torre 1
        torresActivas.Add(false); // Torre 2
        torresActivas.Add(false); // Torre 3
    }

    public void SetTower(int tower)
    {
        // Verifica si el valor de "tower" está dentro del rango válido (1, 2 o 3).
        if (tower >= 1 && tower <= 3)
        {
            // Activa o desactiva la torre correspondiente según el valor de "tower".
            torresActivas[tower - 1] = !torresActivas[tower - 1];
            Debug.Log("Torre " + tower + " activada: " + torresActivas[tower - 1]);
        }
        else
        {
            Debug.LogError("Valor de tower fuera de rango. Debe ser 1, 2 o 3.");
        }
    }

    



    public bool GetTower(int tower)
    {
        return torresActivas[tower];
    }






    public bool SetBattery(bool bateria)
    {
        battery_1 = bateria;

        if(bateria)
        {

            Debug.Log("Bateria en su sitio");

        }
         if(!bateria)
        {
            Debug.Log("Bateria fuera de su sitio");
            
        }

      return bateria;
        
        

    }

    public bool Battery_1
    {
        get { return battery_1; }
        private set { battery_1 = value; }
    }

    public void SetEolicTower()
    {
        eolicTower_1 = true;

    }

    public bool EolicTower_1
    {
        get { return eolicTower_1; }
        private set { eolicTower_1 = value; }
    }








}
