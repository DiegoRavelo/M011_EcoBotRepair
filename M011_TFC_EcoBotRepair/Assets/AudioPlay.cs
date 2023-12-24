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
        if(a == 0 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clips[0], 1f);

        }
        if(a == 1)
        {
             audioSource.PlayOneShot(clips[1], 1f);

        }
      
        

    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
