using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Menu_Manager : MonoBehaviour
{
    
    public static Menu_Manager Instance { get; private set; }

    public Animator transition;

    
    public float time = 1f;

    

    public void Awake()
    {
            if (Instance == null)
        {
            Instance = this;

            
        }
        else
        {
            Destroy(gameObject);
        }

     

        //UIpause.SetActive(false);
    }

    private void Start()
    {

    }

    public void Update()
    {
    

    }

    // public void LoadNextLevel()
    // {
        
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    // }

    public void LoadLevel1()
    {
        
        
        StartCoroutine(LoadLevel(2));

    }

     public void LoadLeve2()
    {
        
        
        StartCoroutine(LoadLevel(3));

    }

     public void LoadLevel3()
    {
        
        
        StartCoroutine(LoadLevel(4));

    }




    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        PlayerPrefs.SetInt("NivelSeleccionado", levelIndex);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("LoadScreen");

    }


    
      IEnumerator LoadGameOver()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("GameOver");

    }

   


 



}

