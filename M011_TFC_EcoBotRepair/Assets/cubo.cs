using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubo : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    public bool reparado;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if(reparado == true)
        {
            anim.SetBool("Reparando", true);
        }        
    }
}
