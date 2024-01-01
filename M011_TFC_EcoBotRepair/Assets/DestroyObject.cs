using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject check;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(check == null)
        {
            Destroy(gameObject);
        }
        
    }
}
