using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetScene : MonoBehaviour
{
    // Start is called before the first frame update
  public void RestartScene()
    {
        // Obtiene el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la escena actual nuevamente para reiniciarla
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(LevelManager.Instance.GetTower(3) == true)
        {
            RestartScene();

        }
        

    }
        
    
}
