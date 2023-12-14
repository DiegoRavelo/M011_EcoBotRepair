using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangCall : MonoBehaviour
{
    // Start is called before the first frame update
     public int towerToObserve;

    public Material[] MaterialsToChange;

    private Renderer rend;

    private GameObject objeto;

    public LayerMask capasAfectadas;

    public delegate void EnergyRecive(int tower, bool isActive);

    public static event EnergyRecive OnEnergyChange;


  

    private void Start()
    {

         rend = GetComponent<Renderer>();

        //LevelManager.TowerStateChanged += HandleTowerStateChanged;

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

                 bool reparado = true;

                objeto.tag = "Cargado";

                 if(called == false)
                 {
                    OnEnergyChange?.Invoke(towerToObserve, reparado);

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
