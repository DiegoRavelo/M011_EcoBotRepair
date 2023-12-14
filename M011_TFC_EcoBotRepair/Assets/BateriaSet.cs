using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaSet : MonoBehaviour
{
    private void Start()
    {
      


    }
   
   private void OnEnable()
    {

          LevelManager.Instance.SetBattery(BateriaNumero);

        print("juan");

        

    }

    [SerializeField]

    private int BateriaNumero;
}
