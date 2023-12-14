using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class ZoomScroll : MonoBehaviour
{
    // Start is called before the first frame update

    public CinemachineVirtualCamera OriginalvirtualCamera;

    private CinemachineFramingTransposer TransposerCamera;

    private float actualDistance;

    void Start()
    {
        TransposerCamera = OriginalvirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        //distance.m_CameraDistance = 1000f;

        ZoomAviable = true;

        
    }

    public float minZoom;
    public float maxZoom;
    public float speedZoom;

    private bool ZoomAviable;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zoom"))
        {
            ZoomAviable = false;

        }
        
    }

    
    void OnTriggerExit(Collider other)
    {
       if(other.CompareTag("Zoom"))
        {
            ZoomAviable = true;

        }
    }


     public void Zoom(InputAction.CallbackContext context)
    {

          if (context.performed && ZoomAviable)
    {
        float zoomDelta = context.ReadValue<float>();

       
        
        
        TransposerCamera.m_CameraDistance += zoomDelta * -1 /speedZoom;

        TransposerCamera.m_CameraDistance = Mathf.Clamp(TransposerCamera.m_CameraDistance, minZoom, maxZoom);
    }

    }
}
