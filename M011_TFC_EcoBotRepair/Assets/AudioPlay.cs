using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
  

    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private AudioSource audioSource;



    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void PlaySound(int a)
    {
       
            audioSource.PlayOneShot(clips[a], 1f);

       
        

    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
