using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public CinemachineVirtualCamera OriginalCamera;
    public CinemachineVirtualCamera LevelSelectorCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePrio()
    {
        LevelSelectorCamera.Priority =  OriginalCamera.Priority + 1;
    }

     public void ChangePrioBack()
    {
        print("hola");
        
        OriginalCamera.Priority =  LevelSelectorCamera.Priority + 1;
    }

}
