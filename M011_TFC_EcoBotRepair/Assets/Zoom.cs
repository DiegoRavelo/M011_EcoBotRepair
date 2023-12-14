using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    

    public float ZoomMax;
    public float duration;

    private float actualZoom;

    
    public CinemachineVirtualCamera OriginalvirtualCamera;

    private CinemachineFramingTransposer TransposerCamera;

    void Start()
    {
         TransposerCamera = OriginalvirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        
    }


      private void OnTriggerEnter(Collider other)
    {
        actualZoom = TransposerCamera.m_CameraDistance;

        if (other.CompareTag("Player"))
        {
            DOTween.To(()=> TransposerCamera.m_CameraDistance, x=> TransposerCamera.m_CameraDistance = x, ZoomMax, duration);
           

        }

    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DOTween.To(()=> TransposerCamera.m_CameraDistance, x=> TransposerCamera.m_CameraDistance = x, actualZoom, duration);
           

        }

    }

   

}
