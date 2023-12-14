using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilEnterExtit : MonoBehaviour
{
    // Start is called before the first frame update



    public GameObject target;

    public Vector3 nuevaEscala;

   


    void Awake()
    {


    }

   

    void Update()
    {
        if(shadowed)
        {
             target.transform.localScale = Vector3.Lerp(target.transform.localScale , new Vector3(1,1,1), Time.deltaTime * 5f);

        }
        else
        {
             
                target.transform.localScale = Vector3.Lerp(target.transform.localScale , Vector3.zero , Time.deltaTime * 5f);

        }

    }

 

    private bool shadowed;

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player"))
        {
            shadowed = true;
           
              

              
         
           


        }

        

        //shadowed = !shadowed;


    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shadowed = false;
           
            
                

        }

      
        //shadowed = !shadowed;


    }

  
}
