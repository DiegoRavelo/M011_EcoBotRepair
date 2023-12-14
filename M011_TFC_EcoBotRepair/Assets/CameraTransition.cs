using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update

   

    public Animator animator;


      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zoom"))
        {
    
            animator.Play("CameraMin");

        }

       

    }

      private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zoom"))
        {

            animator.Play("CameraMax");

        }

       

    }

}
