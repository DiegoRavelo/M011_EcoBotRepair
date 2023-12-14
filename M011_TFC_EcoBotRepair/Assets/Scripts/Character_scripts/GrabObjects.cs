using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class GrabObjects : MonoBehaviour
{

   

    public GameObject cable;

    public GameObject bateriaFake;

    public Animator anim;

    public CinemachineVirtualCamera virtualCameraBattery;

     public CinemachineVirtualCamera virtualCameraCable;

    public CinemachineVirtualCamera OriginalvirtualCamera;

    void Start()
    {
        cable.SetActive(false);

        bateriaFake.SetActive(false);

        anim.Play("Pick");

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cable"))
        {
           

             Destroy(other.gameObject);

             cable.SetActive(true);

             

             

             //GrabingCable();

        }

         if (other.CompareTag("Battery"))
        {
             Destroy(other.gameObject);

             bateriaFake.SetActive(true);

            virtualCameraBattery.Priority = OriginalvirtualCamera.Priority + 1 ;

            Invoke("HandleCameraRetrun", 4f);

             

             //GrabingCable();

        }

    }

     private void HandleCameraRetrun()
    {
        virtualCameraBattery.Priority = OriginalvirtualCamera.Priority - 1 ;

        //OriginalvirtualCamera.Priority = 11;

    }


    private bool picking;


    public void ArrastrarObj(InputAction.CallbackContext context)
    {

        if (context.started || context.performed)
        {
            picking = true;
           
        }
        else 
        {
            picking = false;
        }

    }
}
