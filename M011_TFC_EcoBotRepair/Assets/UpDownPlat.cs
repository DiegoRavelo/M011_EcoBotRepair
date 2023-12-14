using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpDownPlat : MonoBehaviour
{
    // Start is called before the first frame update
    public int towerToObserve;

    private float myFloat;

    public Animator anim;

    void Start()
    {
         LevelManager.TowerStateChanged += PlatUpDown;

       

         
        
    }

    void OnDisable()
    {
        LevelManager.TowerStateChanged -= PlatUpDown;
        
    }

    private  IEnumerator UpDown()
    {
        yield return new WaitForSeconds(3f);

         anim.Play("Down");

    }





    public void PlatUpDown(int tower, bool isActive)
    {
        if(tower == towerToObserve)
        {
            StartCoroutine("UpDown");

          
          

            

        }

        
        


    }
     

    // Update is called once per frame
}   
