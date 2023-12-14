using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCable : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject fakeCable;

    public GameObject realCable;



    public Animator anim;
 


    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        realCable.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if((other.CompareTag("Player") && fakeCable.activeSelf))
        {
           
            realCable.SetActive(true);

            fakeCable.SetActive(false);

            anim.Play("PopCable");

            

        }

    }
}
