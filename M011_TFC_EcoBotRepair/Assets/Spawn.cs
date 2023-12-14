using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LevelManager.Instance.SetRespawnPlace(gameObject.transform.position);
            print("spawn cambiado a " + gameObject.transform.position);      
        }
    }
}
