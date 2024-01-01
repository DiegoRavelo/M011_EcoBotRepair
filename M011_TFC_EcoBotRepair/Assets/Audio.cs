using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;
     void Start()
     {
        audioSource = GetComponent<AudioSource>();
     }   

   private void OnEnable()
   {
     //audioSource.Play();
   }
}
