using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AereoGenerador : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;

    public int MuelleReparar;
    public int TuercaReparar;
    public int MetalReparar;

    public bool reparando;
    public float tiempoReparando;

    void Start()
    {

        



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Pickable == true &&
        GameManager.Instance.MetalTotal >= MetalReparar &&
        GameManager.Instance.MuelleTotal >= MuelleReparar &&
        GameManager.Instance.TuercaTotal >= TuercaReparar && GameManager.Instance.NivelDeCarga >= 2)
        {
            reparando = true;

        }
        if (other.CompareTag("Player") && GameManager.Instance.Pickable == true )
        {
            if (GameManager.Instance.MetalTotal < MetalReparar ||
        GameManager.Instance.MuelleTotal < MuelleReparar ||
        GameManager.Instance.TuercaTotal < TuercaReparar)

                Debug.Log("te faltan materiales");

        }
        if (other.CompareTag("Player") && GameManager.Instance.NivelDeCarga <= 1 && GameManager.Instance.Pickable == true)
        {


            Debug.Log("te falta carga");
        }





    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reparando = false;
            tiempoReparando = 0f;
        }
    }

    public bool torreReparada = false;
    void Update()
    {

        if (reparando)
        {
            tiempoReparando += Time.deltaTime;

            if (tiempoReparando >= 4f && torreReparada == false)
            {

                animator.SetBool("Reparado", true);

                GameManager.Instance.DisminuirNivelDeCarga();

                tiempoReparando = 0f;

                torreReparada = true;

                LevelManager.Instance.SetEolicTower();

                

            }


        }


    }


}
