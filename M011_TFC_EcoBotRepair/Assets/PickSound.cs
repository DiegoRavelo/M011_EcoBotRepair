using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSound : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other )
    {
        if(other.CompareTag("Player"))
        {
            _audioSource.Play();
        }
    }
}
