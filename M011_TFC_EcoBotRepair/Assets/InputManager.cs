using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void Movement(Vector2 _input);

    public static event Movement OnMovementChange;

    private static Vector2 input;

    private static Vector2 _directionMala;

    public static InputManager Instance {get; private set;}

    [SerializeField]

    M011_PlayerController _playerController ;

     [SerializeField]

    IdleSound _idleSound;




    public void Start()
    {
         _playerController = FindObjectOfType<M011_PlayerController>();
        //_playerController = GetComponent<M011_PlayerController>();
         Death.OnKillChange += Nulled;

         

         _idleSound = FindObjectOfType<IdleSound>();

         if(Instance == null)
         {
            Instance = this;
         }
         

        
    }

    public void OnEnable()
    {
        Death.OnKillChange += Nulled;

    }

    public void Nulled()
    {
        StartCoroutine("Nulling");

        //_playerController = null;
    

    }


    public IEnumerator Nulling()
     {
         _playerController = null;

         yield return new WaitForSeconds(1.5f);

          _playerController = FindObjectOfType<M011_PlayerController>();

     }




    public void Move(InputAction.CallbackContext context)
    {


        input = context.ReadValue<Vector2>();

        if(_playerController != null)
        {
             _playerController.Move(input);

             if(context.started)
             {
                _idleSound.PlayFadeIn();
               

               

             }  if(context.canceled)
             {
                 _idleSound.PlayFadeOut();
                


             }
         


        }

        //OnMovementChange?.Invoke(input);

        




    }

    public delegate void Jumping();

    public static event Jumping OnJumpingChange;


    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started && _playerController != null)
        {
             //OnJumpingChange?.Invoke();

             _playerController.Jump();

        }
       
    }
    
    public delegate void Supering();

    public static event Supering OnSuperingChange;

    
    public void Super(InputAction.CallbackContext context)
    {
        
             //OnSuperingChange?.Invoke();
             if(_playerController != null)
             {
                _playerController.SuperSalto();

             }
             

        
       
    }


    public delegate void Repairing(bool repair);

    public static event Repairing OnRepairingChange;


    public void Repair(InputAction.CallbackContext context)
    {
        if (context.performed && _playerController != null)
        {
            _playerController.Repair(true);
        }
        else if (context.canceled && _playerController != null)
        {
            _playerController.Repair(false);
        }


    }

    public delegate void Pausing();

    public static event Pausing OnPausingChange;


    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started && _playerController != null)
        {
               OnPausingChange?.Invoke();
            
        }
     

    }

    public delegate void Spriting();

    public static event Spriting OnSpritingChange;

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.started && _playerController != null)
        {
            //OnSpritingChange?.Invoke();

            _playerController.Sprint();

        }
    

    }

      public bool Interacting
    {
        get { return interacting; }
        private set { interacting = value; }

    }

    public bool interacting;

    
      public void Interact(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            interacting = true;
            
        }
         else if(context.canceled)
        {
            interacting = false;
            
        }
    

    }


}
