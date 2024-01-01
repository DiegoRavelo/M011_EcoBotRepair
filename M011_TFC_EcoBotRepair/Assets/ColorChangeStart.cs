using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeStart : MonoBehaviour
{
  
    // Start is called before the first frame update
    public int towerToObserve;

    public Material[] MaterialsToChange;

    private Renderer rend;

    private GameObject objeto;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

         rend = GetComponent<Renderer>();

        LevelManager.TowerStateChanged += HandleTowerStateChanged;

        objeto = gameObject;

        
       
    }



    public void HandleTowerStateChanged(int tower, bool isActive)
    {
        

         if (tower == towerToObserve)
        {
            // StartCoroutine(ColorAnimation());
            
            
                
                Material material = rend.material;

                material = MaterialsToChange[1];

                rend.material = material;

                objeto.tag = "Cargado";

                audioSource.Play();
            
       
        }

    }




    
}
