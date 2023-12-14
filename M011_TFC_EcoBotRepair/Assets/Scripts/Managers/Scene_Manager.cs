using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Scene_Manager : MonoBehaviour
{
    
    public static Scene_Manager Instance { get; private set; }

    public Animator transition;

    public CharacterController characterController = null;
    
    public float time = 1f;

    public GameObject UIpause = null;

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

        if (UIpause != null)
         {
         UIpause.SetActive(false);
         }

        //UIpause.SetActive(false);
    }

    private void OnEnable()
    {
        InputManager.OnPausingChange += Pause;

    }

    private void OnDisable()
    {
         InputManager.OnPausingChange -= Pause;

    }


    public void Update()
    {
    

        if(paused == true)
        {
            Time.timeScale = 0;

            if(characterController != null)
            {
                characterController.enabled = false;

            }

           


         }

        if(paused == false)
         {
             Time.timeScale = 1;

             if(characterController != null)
            {
                characterController.enabled = true;

            }

            


         }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadMainMenu()
    {
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        StartCoroutine(LoadLevel(0));
        paused = false;

        if (UIpause != null)
       {
         UIpause.SetActive(false);
       }

        
        //UIpause.SetActive(false);
        
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        // transition.SetTrigger("Start");
        // yield return new WaitForSeconds(time);
        // SceneManager.LoadScene(levelIndex);


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

    public bool paused;

     public void Pause()
    {
         
            paused = true;
        



           if( paused == true && Time.timeScale == 0f)
         {
             Time.timeScale = 1;

             if(UIpause != null)
             {
                 UIpause.SetActive(false);

             }
               //characterController.enabled = true;

            if(characterController != null)
            {
                characterController.enabled = false;

            }

            print("hola");
         }

         if (UIpause != null)
         {
            UIpause.SetActive(true);
        }

        

    }

    public void Resume()
    {
        Time.timeScale = 1;
        if (UIpause != null)
        {
          UIpause.SetActive(false);
         }

        //UIpause.SetActive(false);

        if(characterController != null)
            {
                characterController.enabled = true;

            }

       // characterController.enabled = true;

        paused = false;

        

        print("hola");

    }



}
