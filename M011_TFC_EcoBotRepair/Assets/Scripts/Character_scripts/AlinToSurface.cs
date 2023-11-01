using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlinToSurface : MonoBehaviour
{

    void Update()
    {
        AlinToSurfaceFunc();
    }

    [SerializeField]
    private float velocidadInclinacion;

    public void AlinToSurfaceFunc()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.6f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Vector3 normal = hit.normal;
                Quaternion rotacionDeseada = Quaternion.FromToRotation(transform.up, normal) * transform.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadInclinacion * Time.deltaTime);

            }
        }

    }


}
