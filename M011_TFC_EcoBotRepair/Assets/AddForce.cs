using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    
     public float fuerza = 10f;

    void Start()
    {
        AplicarFuerzaAleatoria();
    }

    void AplicarFuerzaAleatoria()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Generar un ángulo aleatorio en el rango de 45 grados hacia adelante, atrás, izquierda o derecha.
        float anguloAleatorio = Random.Range(-45f, 45f);

        // Convertir el ángulo a radianes.
        float anguloEnRadianes = anguloAleatorio * Mathf.Deg2Rad;

        // Calcular las componentes x e y de la dirección de la fuerza.
        float direccionX = Mathf.Cos(anguloEnRadianes);
        float direccionY = Mathf.Sin(anguloEnRadianes);

        // Crear un vector de dirección con la componente y hacia arriba.
        Vector3 direccionFuerza = new Vector3(direccionX, 1f, direccionY);

        // Normalizar el vector de dirección para asegurar que solo tenga una magnitud de 1.
        direccionFuerza.Normalize();

        // Aplicar la fuerza al objeto en la dirección calculada.
        rb.AddForce(direccionFuerza * fuerza, ForceMode.Impulse);
    }
}
