using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeCable : MonoBehaviour
{
    // Start is called before the first frame update
     public int cableToObserve;

    public Material[] MaterialsToChange;

    private Renderer rend;

    private GameObject objeto;

    public LayerMask capasAfectadas;

    private void Start()
    {

        rend = GetComponent<Renderer>();

        objeto = gameObject;
        
       
    }

    public float distancia;

    public Vector3 laser;

    private bool called = false;

    private bool a = false;



   

    void Update()
    {
        RaycastHit hit;

        Vector3 localRight = transform.TransformDirection(laser);

        if (Physics.Raycast(transform.position, localRight , out hit, distancia , capasAfectadas))
        {
             if (hit.collider.CompareTag("Cargado"))
            {
                 ColorAnimation();

                objeto.tag = "Cargado";

                 if(called == false)
                 {
                    LevelManager.Instance.SetCable(cableToObserve);

                    called = true;

                 }

                

                 
               
            }
             if (hit.collider.CompareTag("Descargado"))
            {
                 ColorAnimationBack();

                 objeto.tag = "Descargado";
               
            }
            
        }
         else 
            {
               
                 ColorAnimationBack();
                 objeto.tag = "Descargado";
                
                
            }

        

        Debug.DrawRay(transform.position, localRight * distancia, Color.red);

        
  
    }



    public void HandleTowerStateChanged(int tower, bool isActive)
    {
        // print("hola"); 

        //  if (tower == towerToObserve)
        // {
        //     // StartCoroutine(ColorAnimation());
            
            
                
        //        Material material = rend.material;

        //        material = MaterialsToChange[1];

        //       rend.material = material;
            
       
        // }

    }

    private void ColorAnimation()
    {
        Material material = rend.material;

        //yield return new WaitForSeconds(0.5f);
        
        material = MaterialsToChange[1];

        rend.material = material;

    }

    private void ColorAnimationBack()
    {
        Material material = rend.material;

    

        //yield return new WaitForSeconds(0.5f);
        
        material = MaterialsToChange[0];

        rend.material = material;

    }
}
