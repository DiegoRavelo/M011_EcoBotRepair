using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer laser;

    public Transform mira;

    public float distanciaMax;

    public delegate void Killed();

    public static event Killed OnLaserHit;

    void Start()
    {
        laser.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
            ShootLaser();
        
    }

    
    private void ShootLaser()
    {
         Activate();

        
        Vector3 laserStart = mira.position;

        // Obtiene la dirección del láser desde la rotación del GameObject
        
        // Calcula la posición final del láser
       

        Vector3 laserDirection = mira.forward;

         Vector3 laserEnd = laserStart + laserDirection * distanciaMax;

        // Actualiza las posiciones del LineRenderer
        laser.SetPosition(0, laserStart);
        laser.SetPosition(1, laserEnd);


        // Puedes realizar otras acciones aquí, como detectar colisiones con objetos, aplicar daño, etc.
    }
    

    private void Activate()
    {
        laser.enabled = true;
    }

    private void Deactivate()
    {
        laser.enabled = false;
    }
}
