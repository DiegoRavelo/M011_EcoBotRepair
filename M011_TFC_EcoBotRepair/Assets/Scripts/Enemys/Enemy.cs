using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform centroDelCirculo; // El GameObject central
    public float radio = 5.0f; // Radio del círculo
    public float velocidad = 2.0f; // Velocidad de rotación

     private CharacterController characterController;

    private Vector3 posicionInicial;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Calcula la nueva posición en el círculo
        float angulo = Time.time * velocidad;
        Vector3 posicionNueva = centroDelCirculo.position + new Vector3(Mathf.Cos(angulo) * radio, 0, Mathf.Sin(angulo) * radio);

        Vector3 desplazamiento = posicionNueva - transform.position;

        
        // Mueve el enemigo hacia la nueva posición
        characterController.Move(desplazamiento);
    }
}
