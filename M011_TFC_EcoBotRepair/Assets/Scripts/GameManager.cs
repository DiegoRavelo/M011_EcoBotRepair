using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales {get; private set;}
    private int metalTotal;

    private int tuercaTotal;

    public bool pickable;

    public float totalSprintTime;
    public float remainingSprintTime;

    private int muelleTotal;

     
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

        

        Debug.Log(nivelDeCarga);


    }



    public void Pick(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            pickable = true;
        }
        else
        {
            pickable = false;

        }
    }

    public void SumarPuntosMetal(int puntosASumar)
    {
        metalTotal += puntosASumar;
        Debug.Log("Tienes " + metalTotal + " de metal" );
    }

    public void SumarPuntosTuerca(int puntosASumar)
    {
        tuercaTotal += puntosASumar;
        Debug.Log("Tienes " + tuercaTotal + " de tuerca" );
    }

    public void SumarPuntosMuelle(int puntosASumar)
    {
        muelleTotal += puntosASumar;
        Debug.Log("Tienes " + muelleTotal + " de muelle" );
    }

    
    public void EstablecerCooldown()
    {

    
        remainingSprintTime = 5f;

        totalSprintTime = 5f;

    }

    public void ReducirCooldown()
    {
        remainingSprintTime = 0f;

    }


    public void DisminuirCooldown()
    {

        remainingSprintTime -= Time.deltaTime;

        if (remainingSprintTime < 0f)
         {
         remainingSprintTime = 0f;
         }
        

    }

    // Inicialmente el nivel de carga es 1.

    public bool Pickable
    {
       get { return pickable; }
        private set { pickable = value; }   
    }

    public float RemainingSprintTime
    {
        get { return remainingSprintTime; }
        private set { remainingSprintTime = value; }
    }

    public float TotalSprintTime
    {
        get { return totalSprintTime; }
        private set { totalSprintTime = value; }
    }
    public int NivelDeCarga
    {
        get { return nivelDeCarga; }
        private set { nivelDeCarga = value; }
    }

    public int MetalTotal
    {
        get { return metalTotal; }
        private set { metalTotal = value; }
    }

     public int TuercaTotal
     {
        get { return tuercaTotal; }
        private set { tuercaTotal = value; }
    }

     public int MuelleTotal
     {
        get { return muelleTotal; }
        private set { muelleTotal = value; }
    }

   

     public int nivelDeCarga = 4;

    public void AumentarNivelDeCarga()
    {
        if (nivelDeCarga < 4)
        {
            nivelDeCarga++;
            Debug.Log("Nivel de carga aumentado a " + nivelDeCarga);
        }
        else
        {
            Debug.Log("El nivel de carga ya está en su máximo valor.");
        }
    }

     public void DisminuirNivelDeCargaPorSalto()
    {
        if (nivelDeCarga == 2)
        {
            nivelDeCarga--;
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
        }
        if (nivelDeCarga == 3)
        {
            nivelDeCarga--;
            ReducirCooldown();
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
        }
        if (nivelDeCarga == 4)
        {
            nivelDeCarga--;
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
            EstablecerCooldown();
        } 
        
        
    }

    public void DisminuirNivelDeCarga()
    {
        if (nivelDeCarga == 2)
        {
            nivelDeCarga--;
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
        }
        if (nivelDeCarga == 3)
        {
            nivelDeCarga--;
            //ReducirCooldown();
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
        }
        if (nivelDeCarga == 4)
        {
            nivelDeCarga--;
            Debug.Log("Nivel de carga disminuido a " + nivelDeCarga);
            EstablecerCooldown();
        } 
        
        
    }

    


    // public bool Epressed ()
    
    

    

    
}