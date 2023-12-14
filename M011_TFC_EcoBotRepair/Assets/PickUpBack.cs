using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Stencil;
    public GameObject ObjectNormal;

    void Start()
    {
        Stencil.transform.localScale = Vector3.zero;        
    }

    



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            

           

            DOTween.To(()=> Stencil.transform.localScale , x=> Stencil.transform.localScale = x, ObjectNormal.transform.localScale, 0.5f);



        }
    }

     private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {

             DOTween.To(()=> Stencil.transform.localScale , x=> Stencil.transform.localScale = x, Vector3.zero, 0.5f);
        




        }
    }
    
}
