using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StencilEnterExtit : MonoBehaviour
{
    // Start is called before the first frame update



    public GameObject target;

    public Vector3 nuevaEscala;

    public MeshRenderer CharacterTexture;
    public MeshRenderer CharacterTextureChain;


    void Awake()
    {


    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         if (shadowed == true)
    //         {
    //             shadowed = false;
    //             print(shadowed);

    //         }

    //         else
    //         {
    //             shadowed = true;
    //             print(shadowed);

    //         }

    //         //shadowed = !shadowed;
    //     }


    // }

    private bool shadowed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Siluete"))
        {
            if (GameManager.Instance.Shadowed == true)
            {
                other.transform.localScale = nuevaEscala;
                //CharacterTexture.enabled = false;
                //CharacterTextureChain.enabled = false;
            }
            else
            {
                other.transform.localScale = Vector3.zero;
                //CharacterTexture.enabled = true;
                //CharacterTextureChain.enabled = true;
            }


        }

        GameManager.Instance.ShadowChange();

        //shadowed = !shadowed;


    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Siluete"))
        {
            if (GameManager.Instance.Shadowed == true)
            {
                other.transform.localScale = nuevaEscala;
                //CharacterTexture.enabled = false;
                //CharacterTextureChain.enabled = false;
            }
            else
            {
                other.transform.localScale = Vector3.zero;
                //CharacterTexture.enabled = true;
                //CharacterTextureChain.enabled = true;
            }


        }

        GameManager.Instance.ShadowChange();

        //shadowed = !shadowed;


    }

    public float scaleChangeSpeed = 2.0f;

    public void Update()
    {

        if (GameManager.Instance.Shadowed == true)
        {
            //target. transform.localScale = nuevaEscala;

            Vector3 currentScale = target.transform.localScale;

            target.transform.localScale = Vector3.Lerp(currentScale, nuevaEscala, Time.deltaTime * scaleChangeSpeed);

            //target.transform.localScale = nuevaEscala;

            CharacterTexture.enabled = false;
            CharacterTextureChain.enabled = false;

        

        }
        if (GameManager.Instance.Shadowed == false)
        {
            Vector3 currentScale = target.transform.localScale;

            target.transform.localScale = Vector3.Lerp(currentScale, Vector3.zero, Time.deltaTime * scaleChangeSpeed);

           //if (target.transform.localScale.x < 0.8f)
            //{
                CharacterTexture.enabled = true;
                CharacterTextureChain.enabled = true;
            //}

            //target.transform.localScale = Vector3.zero;
        }




    }
}
