using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimationManager : MonoBehaviour {

  public Animator animator;

  private string currentState;

      private void OnEnable()
    {
        M011_PlayerController.OnAnimationChange += ChangeAnimationState;
    }

     private void OnDisable()
    {
        M011_PlayerController.OnAnimationChange -= ChangeAnimationState;
    }

        private void ChangeAnimationState(string newState)
    {
       

        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;

        print(currentState);
    }
    
}
 