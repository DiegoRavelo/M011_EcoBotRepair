using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AereoGeneradorFinal : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;

    public int TorreNumero;

    void Update()
    {

        bool tower0 = LevelManager.Instance.GetTower(0);
        bool tower1 = LevelManager.Instance.GetTower(1);
        bool tower2 = LevelManager.Instance.GetTower(2);

        if (tower0 && tower1 && tower2)
        {
            LevelManager.Instance.SetTower(4);
             animator.SetBool("Reparado", true);
        }
        else
        {
             animator.SetBool("Reparado", false);
        }


    }



}