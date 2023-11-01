using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{

    private bool adherido = false;

    private bool adherible;

    public GameObject cubo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            cubo = other.gameObject;
            adherible = true;
        }

    }


    public void ArrastrarObj(InputAction.CallbackContext context)
    {

        if (context.started && adherible)

        {

            if (!adherido)
            {
                // Mueve el cubo justo delante del personaje y lo convierte en un hijo del personaje.
                cubo.transform.position = transform.position + transform.forward * -1.0f;
                cubo.transform.SetParent(transform);


                cubo.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                adherido = true;
            }
            else
            {
                // Desvincula el cubo del personaje.

                cubo.transform.SetParent(null);
                cubo.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                adherido = false;
            }

        }

    }
}
