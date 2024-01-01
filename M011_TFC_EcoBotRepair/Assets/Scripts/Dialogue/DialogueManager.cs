using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text nameText;

    public TMP_Text dialogueText;

    public static DialogueManager Instance {get; private set;}

    public Queue<string> sentences;

    private AudioSource audioSource;

    public Animator anim;

    [SerializeField]

    M011_PlayerController _playerController ;

  

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        sentences  = new Queue<string>();

        audioSource = GetComponent<AudioSource>();

         _playerController = FindObjectOfType<M011_PlayerController>();

        
        
    }

      public void ControlOnOff()
    {
        if(_playerController.enabled == true)
        {
             _playerController.enabled = false;

        }
        else if(_playerController.enabled == false)
        {
            _playerController.enabled = true;
        }
        
        
    

    }

    public void StartDialogue(Dialogue dialogue)
    {
        print(dialogue.name);

        ControlOnOff();

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueText.text = "";

        DisplayNextSentence();
    }

     public void StartDialogueBoss(Dialogue dialogue)
    {
        print(dialogue.name);

        ControlOnOff();

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueText.text = "";

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

          if (currentCoroutine != null)
    {
        StopCoroutine(currentCoroutine);
    }

        string sentence = sentences.Dequeue();

        print(sentence);

        
        

        dialogueText.text = "";

        currentCoroutine = StartCoroutine(MostrarPalabrasOrdeandas(sentence));

        //dialogueText.text = sentence;
    }

    private Coroutine currentCoroutine;

    public float intervalo = 0.05f;

    IEnumerator MostrarPalabrasOrdeandas(string sentence)
    {
        // foreach (char character in sentence)
        // {
        //     dialogueText.text += character;
        //     yield return new WaitForSeconds(0.05f);
        // }

        audioSource.Play();

        

        anim.Play("DialogueAlpha");

        for (int i = 0; i < sentence.Length; i++)
        {
        dialogueText.text += sentence[i];
        yield return new WaitForSeconds(intervalo);
        }

         if (dialogueText.text.Length == sentence.Length)
        {

            audioSource.Stop();

            
       
        yield return new WaitForSeconds(0.2f);

        endedDialogue = true;
        
         
        
        }

    }


    private bool endedDialogue;

    public void NextSentence()
    {
        if(endedDialogue)
        {
             DisplayNextSentence();

             endedDialogue = false;

        }
        
       

    }

    public void DisminuirIntervalo()
    {
        intervalo = 0.01f;
    }

      public void AumentarIntervalo()
    {
        intervalo = 0.05f;
    }


    public void EndDialogue()
    {
        //dialogueText.text = " ";

        anim.Play("DialogueAlpha-1");

        ControlOnOff();

    }

    
}
