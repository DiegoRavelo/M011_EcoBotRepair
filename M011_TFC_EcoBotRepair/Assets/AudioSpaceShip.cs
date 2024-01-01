using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioSpaceShip : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioSource;

    public ParticleSystem[] sp;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Invoke("FadeOut", 20f);
      
    }

    public void FadeIn()
    {
        print("holaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        audioSource.Play();

        DOTween.To(()=> audioSource.volume, x=> audioSource.volume = x, 1f, 5f);
    }

    public void FadeOut()
    {
         DOTween.To(()=> audioSource.volume, x=> audioSource.volume = x, 0f, 2f);

    }

    public void Emision()
    {
        var em1 = sp[0].emission;
        var em2 = sp[1].emission;
                   
       
        //DOTween.To(()=> em1.rateOverTime, x=>  em1.rateOverTime = x, 0f, 2f);
        //DOTween.To(()=> em2.rateOverTime, x=>  em2.rateOverTime = x, 0f, 2f);
        
                
    }

 
}
