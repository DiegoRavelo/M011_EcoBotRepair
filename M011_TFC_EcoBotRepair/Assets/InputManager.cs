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


    public void Move(InputAction.CallbackContext context)
    {

        input = context.ReadValue<Vector2>();

        OnMovementChange?.Invoke(input);



    }

    public delegate void Jumping();

    public static event Jumping OnJumpingChange;


    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
             OnJumpingChange?.Invoke();

        }
       
    }
    
    public delegate void Supering();

    public static event Supering OnSuperingChange;

    
    public void Super(InputAction.CallbackContext context)
    {
        
             OnSuperingChange?.Invoke();

        
       
    }


    public delegate void Repairing(bool repair);

    public static event Repairing OnRepairingChange;


    public void Repair(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnRepairingChange?.Invoke(true);
        }
        else if (context.canceled)
        {
            OnRepairingChange?.Invoke(false);
        }


    }

    public delegate void Pausing();

    public static event Pausing OnPausingChange;


    public void Pause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
               OnPausingChange?.Invoke();
            
        }
     

    }

    public delegate void Spriting();

    public static event Spriting OnSpritingChange;

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OnSpritingChange?.Invoke();

        }
    

    }


}
