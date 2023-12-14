using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFolower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MAIN25;
    public float offsetY; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = MAIN25.transform.position;
        newPosition.y += offsetY; 
        transform.position = newPosition;
        
    }
}
