using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesTransition : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem[] sistemaParticulasR;
    public ParticleSystem[] sistemaParticulasL;

    public int[] rate;

    void Start()
    {
        for( int i = 0; i < sistemaParticulasL.Length; i++)
        {
            sistemaParticulasL[i].Pause();
            sistemaParticulasR[i].Pause();

           
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        M011_PlayerController.OnParticleChange += ChangeParticleState;
    }

    private void OnDisable()
    {
        M011_PlayerController.OnParticleChange -= ChangeParticleState;
    }

    private void ChangeParticleState(int a, bool p)
    {

      if (p == true)
    {
         sistemaParticulasL[a].Play();
         sistemaParticulasR[a].Play();

        var emL = sistemaParticulasL[a].emission;
        var emR = sistemaParticulasR[a].emission;

    
        emL.rateOverTime = rate[a];
        emR.rateOverTime = rate[a];

       


         

       
        
    }
     else 
    {
        
        var emL = sistemaParticulasL[a].emission;
        var emR = sistemaParticulasR[a].emission;

        emL.rateOverTime = 0f;
        emR.rateOverTime = 0f;

       
        
    }


        
    }

}
