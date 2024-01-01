using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

      
    [SerializeField]

    M011_PlayerController _playerController ;

    void Start()
    {
        _playerController = FindObjectOfType<M011_PlayerController>();
        Invoke("Destroy", 0.5f);
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerController.Killed();

        }
    }
}
