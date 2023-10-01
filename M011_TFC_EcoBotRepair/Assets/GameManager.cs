using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales {get; private set;}
    private int metalTotal;

     private bool isEKeyPressed = false;
    
     public bool IsEKeyPressed()
    {
        return isEKeyPressed;
    }

    public void SetEKeyPressed(bool value)
    {
        isEKeyPressed = value;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        metalTotal += puntosASumar;
        Debug.Log("Tienes " + metalTotal + " de metal" );
    }

    

    // public bool Epressed ()
    
    

    

    
}