using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BateriaPick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bateriaReal;

    public CinemachineVirtualCamera virtualCamera;

    public CinemachineVirtualCamera OriginalvirtualCamera;



   
    void Start()
    {
        bateriaReal.SetActive(false);
        
    }

   private void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    {

        //bateriaReal.SetActive(true);
        Destroy(this);

    }
   }
}
