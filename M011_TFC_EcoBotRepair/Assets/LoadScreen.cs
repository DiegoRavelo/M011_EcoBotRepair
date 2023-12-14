using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;

    public float time;

    int NivelACargar; 

    void Start()
    {
        
       

        time = Random.Range(4, 7);

        NivelACargar = PlayerPrefs.GetInt("NivelSeleccionado", 0);

         StartCoroutine(LoadLevel(NivelACargar));
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator LoadLevel(int levelIndex)
    {
        
        
        yield return new WaitForSeconds(time);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);

    }

}
