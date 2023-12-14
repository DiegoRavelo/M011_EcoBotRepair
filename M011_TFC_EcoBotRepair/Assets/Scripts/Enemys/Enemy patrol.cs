using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemypatrol : MonoBehaviour
{
    // Start is called before the first frame update+
    public Transform[] patrolPoints;

    public int targetPoint;

    public float TreshHold;

    public float speed;

    public float rotationSpeed;

    public Animator anim;


    private Vector3 InicialPoistion;

    public EstadoEnemigo estadoActual;

    private float startSpeed;

    public float sprint;
    

    void Awake()
    {
        startSpeed = speed;

    }






    void Start()
    {

        // InicialPoistion = transform.position;
        // patroling = true;
        // targetPoint = 0;

        estadoActual = EstadoEnemigo.Waiting;

        

      

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            estadoActual = EstadoEnemigo.Patroling;

            speed = sprint;

            //LevelManager.Instance.Respawn();

           

            
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DOTween.To(()=> speed, x=> speed= x, startSpeed, 1);
        }
    }



 
    void Update()
    {
           Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;
          //float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

            // transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
            

            // Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;

            

         switch (estadoActual)
        {
        
            case EstadoEnemigo.Patroling:
    

            float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

            
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }

            if (distanceToTarget < 1f)
            {
                estadoActual = EstadoEnemigo.Waiting;

                 targetPoint += 1; // Cambia al siguiente punto de patrulla
                 if(targetPoint >= patrolPoints.Length)
                 {
                    targetPoint = 0;
                 }
             }

            
            
                break;

            case EstadoEnemigo.Following:
               
                break;

            case EstadoEnemigo.Atacando:
               
                break;

            case EstadoEnemigo.Waiting:

              

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
               
                break;

                

            
        }

        


    }

       void CambiarEstado(EstadoEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }

    public enum EstadoEnemigo
{
    Waiting,
    Patroling,
    Following,
    Atacando
}


}
