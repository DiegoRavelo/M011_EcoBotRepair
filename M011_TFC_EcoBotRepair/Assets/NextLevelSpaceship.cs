using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelSpaceship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    private bool[] tower;

    // Update is called once per frame
    void Update()
    {
          
        
      
    }

 


    public Animator spaceShip;


    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    
    public delegate void EndLevelHandler();
    public static event EndLevelHandler OnLevelEndChange;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player") )
        {
              
            bool tower0 = LevelManager.Instance.GetTower(0);
            bool tower1 = LevelManager.Instance.GetTower(1);
            bool tower2 = LevelManager.Instance.GetTower(2);
            bool tower3 = LevelManager.Instance.GetTower(3);

            if(tower0 && tower1 && tower2 && tower3)
            {


            OnLevelEndChange?.Invoke();

            Invoke("NextLevel", 8f);

            spaceShip.Play("Rotation-1");

            anim1.Play("DoorLEFT-1");
            anim2.Play("DoorRIGHT-1");
            anim3.Play("DoorDOWN-1");

            }
        

        }

    }

    private void NextLevel()
    {
        Scene_Manager.Instance.LoadNextLevel();

    }

    
}
