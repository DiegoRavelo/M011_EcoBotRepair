using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeBattery : MonoBehaviour
{
    public int towerToObserve;

    public Material[] MaterialsToChange;

    private Renderer rend;

    private GameObject objeto;

   

  

    private void Start()
    {

         rend = GetComponent<Renderer>();

        

        objeto = gameObject;

        

        
        
    

        
       
    }

    public float distancia;

    public Vector3 laser;

    public LayerMask capasAfectadas;

   

    void Update()
    {
        RaycastHit hit;

        Vector3 localRight = transform.TransformDirection(laser);

        if (Physics.Raycast(transform.position, localRight , out hit, distancia, capasAfectadas))
        {
             if (hit.collider.CompareTag("Cargado"))
            {
                ColorAnimation();

                 
               
            }
            
        }
         else 
            {
               
                 ColorAnimationBack();
                 objeto.tag = "Descargado";
                
                
            }

        

        Debug.DrawRay(transform.position, localRight * distancia, Color.red);

        
  
    }



    private void ColorAnimation()
    {   
         Material material = rend.material;

        //yield return new WaitForSeconds(0.5f);
        
        material = MaterialsToChange[1];

        rend.material = material;

        
            StartCoroutine("ColorWait");

       

    }

    private IEnumerator ColorWait()
    {
        yield return new WaitForSeconds(0.5f);

        objeto.tag = "Cargado";
       

    }

    private void ColorAnimationBack()
    {
        Material material = rend.material;

        //yield return new WaitForSeconds(0.5f);
        
        material = MaterialsToChange[0];

        rend.material = material;

    }

   



    

    
}
