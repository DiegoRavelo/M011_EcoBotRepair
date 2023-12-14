using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public delegate void Killed();

    public static event Killed OnKillChange;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
        
            //LevelManager.Instance.Respawn();

            OnKillChange?.Invoke();  

            
        }
    }
    
}
