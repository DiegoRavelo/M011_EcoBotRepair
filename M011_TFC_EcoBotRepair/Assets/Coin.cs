using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    //public AudioClip coinSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.IsEKeyPressed() == true)
        {
            GameManager.Instance.SumarPuntos(valor);
            Destroy(this.gameObject);
            //AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }
}