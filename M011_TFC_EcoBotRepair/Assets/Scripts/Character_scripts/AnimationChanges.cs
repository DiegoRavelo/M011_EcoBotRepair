using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationChanges : MonoBehaviour
{
    public Animator animatorCadena1;
    public Animator animatorCadena2;

    public Animator[] animators;

    private string currentState;

    private void OnEnable()
    {
        M011_PlayerController.OnAnimationChange += ChangeAnimationState;
    }

    private void OnDisable()
    {
        M011_PlayerController.OnAnimationChange -= ChangeAnimationState;
    }

    private void ChangeAnimationState(int a, string newState)
    {

        animators[a].Play(newState);

        if( a == 0 )
        {
            animators[1].Play(newState);
        }
        
        

        if(currentState != newState)
        {


            //print(currentState);

             currentState = newState;
            

        }

        

        
      
        
    }

    
        //if (currentState == newState) return;

        //animator.Play(newState);

        //currentState = newState;
}
