using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other) 
   {
       if (other.CompareTag("Player"))
       {
          SceneManager.LoadScene("GameOver");
       }
   }
}
