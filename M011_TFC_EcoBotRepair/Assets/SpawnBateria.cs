using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnBateria : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fakeBateria;

    public GameObject realBateria;

    public GameObject batterycheck;

    
    public CinemachineVirtualCamera virtualCamera = null;
    public CinemachineVirtualCamera OriginalvirtualCamera = null;




    void Start()
    {
        realBateria.SetActive(false);

    }

  

    public int BateriaNumero;

    private void OnTriggerStay(Collider other)
    {
        if((other.CompareTag("Player") && fakeBateria.activeSelf))
        {
            realBateria.SetActive(true);
            

            fakeBateria.SetActive(false);

            CameraHandle();

            

            

        }

    }

    private void CameraHandle()
    {
        bool called = false;

        if(!called)
        {
            called = true;

            virtualCamera.Priority = OriginalvirtualCamera.Priority + 1 ;

             Invoke("HandleCameraRetrun", 4f);


        }
        
    }

  

    private void HandleCameraRetrun()
    {
         virtualCamera.Priority = OriginalvirtualCamera.Priority - 1 ;
    

    }
}
