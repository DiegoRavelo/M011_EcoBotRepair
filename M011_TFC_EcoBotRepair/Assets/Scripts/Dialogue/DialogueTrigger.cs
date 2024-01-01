using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
   public Dialogue dialogue;

   private bool called = false;

   public void OnTriggerStay(Collider other)
   {
       
    
       if(other.CompareTag("Player") && InputManager.Instance.interacting == true && !called)
       {
          called = true;
          DialogueManager.Instance.StartDialogue(dialogue);
       }
      

   }

   public void OnTriggerExit(Collider other)
   {
     if(other.CompareTag("Player"))
     {
        called = false;

     }

   }

 
 
   
}
