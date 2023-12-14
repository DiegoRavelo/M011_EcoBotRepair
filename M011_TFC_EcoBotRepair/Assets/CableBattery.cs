using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBattery : MonoBehaviour
{
    // Start is called before the first frame update
      public int cableToObserve;

    public Material[] MaterialsToChange;

    private Renderer rend;

    private GameObject objeto;

    
    private void Start()
    {

        rend = GetComponent<Renderer>();

        objeto = gameObject;
        
       
    }

  

  

    private bool called = false;

    



   

    void Update()
    {
        if(LevelManager.Instance.GetCable(cableToObserve))
        {
            bool called = false;

            if(!called)
            {
                ColorAnimation();
                called = true;
            }

        }
        

        


        
  
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
