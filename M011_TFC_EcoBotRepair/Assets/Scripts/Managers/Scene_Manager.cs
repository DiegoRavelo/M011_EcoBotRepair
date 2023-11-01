using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Scene_Manager : MonoBehaviour
{
    
    public static Scene_Manager Instance { get; private set; }
    public Animator transition;

    public CharacterController characterController;
    
    public float time = 1f;

    public GameObject UIpause = null;

    public void Awake()
    {
        UIpause.SetActive(false);
    }

    public void Update()
    {
    

        if(paused == true)
         {
             Time.timeScale = 0;

            characterController.enabled = false;


         }

         if(paused == false)
         {
             Time.timeScale = 1;

            characterController.enabled = true;


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
        StartCoroutine(LoadLevel(0));
        UIpause.SetActive(false);
        Time.timeScale = 1;
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(levelIndex);

    }


    
      IEnumerator LoadGameOver()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("GameOver");

    }

    public bool paused;

     public void Pause(InputAction.CallbackContext context)
    {
        if( context.performed || context.started)
        {
            
            paused = true;
        }

           if( context.performed || context.started && paused == true)
         {
             Time.timeScale = 1;
            UIpause.SetActive(false);

            characterController.enabled = true;
         }

        UIpause.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1;

        UIpause.SetActive(false);

        characterController.enabled = true;

        paused = false;

    }



}
