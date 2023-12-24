using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdleSound : MonoBehaviour
{
    // Start is called before the first frame update

    bool playing;

    [SerializeField]

    private AudioSource audioSource;

    private float startVolume;

    public float speed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

     
        

        
        
    }

    void Update()
    {

    }


    public void PlayFadeIn()
    {
        
        print("hola");

      DOTween.To(()=> audioSource.volume, x=> audioSource.volume = x, 1f, 1f);
   
    }

    public void PlayFadeOut()
    {
      DOTween.To(()=> audioSource.volume, x=> audioSource.volume = x, 0f, 1f);
   
    }

// private IEnumerator FadeIn()
// {

//     while (audioSource.volume < 1f)
//     {
//         audioSource.volume += speed * Time.deltaTime;
//         yield return null;
//     }

//     audioSource.volume = 1f; // Asegurar que el volumen sea exactamente 1 al final del fade in
// }

// private IEnumerator FadeOut()
// {
//     while (audioSource.volume > 0f )
//     {
//         audioSource.volume -= speed * Time.deltaTime;
//         yield return null;
//     }

//     audioSource.volume = 0f; // Asegurar que el volumen sea exactamente 0 al final del fade out
// }






    // private IEnumerator FadeIn()
    // {
    //     float elapsedTime = 0.0f;

    //     // Gradualmente aumentar el volumen hasta 1.0
    //     while (elapsedTime < 1f)
    //     {
    //         audioSource.volume = Mathf.Lerp(0.0f, startVolume, elapsedTime);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    // }

    // private IEnumerator FadeOut()
    // {
    //     float elapsedTime = 0.0f;
    //     float startVolume = audioSource.volume;

    //     // Gradualmente disminuir el volumen hasta 0.0
    //     while (elapsedTime < 1f)
    //     {
    //         audioSource.volume = Mathf.Lerp(startVolume, 0.0f, elapsedTime);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    

    // }



    
}
