using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si ha chocado con el suelo
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     // Calcula y aplica una fuerza de rebote
        //     if(timesCollided)
        //     Vector3 normal = collision.contacts[0].normal;
        //     Vector3 reflejado = Vector3.Reflect(transform.forward, normal);
        //     GetComponent<Rigidbody>().AddForce(reflejado * 100f, ForceMode.Impulse);
        //     print("bounce");
        // }
    }

}
