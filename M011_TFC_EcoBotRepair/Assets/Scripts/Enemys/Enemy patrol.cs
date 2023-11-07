using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypatrol : MonoBehaviour
{
    // Start is called before the first frame update+
    public Transform[] patrolPoints;
    public int targetPoint;

    public float TreshHold;
    public float speed;

    public float rotationSpeed;

    private Vector3 InicialPoistion;

    void Awake()
    {


    }



    void Start()
    {
        InicialPoistion = transform.position;
        patroling = true;
        targetPoint = 0;
    }

    public bool patroling;

    public bool Ataque;
    public bool Detencion;

    public LayerMask capaDeljugador;

    public GameObject target;

    public bool AttackDone;

    // Update is called once per frame
    void Update()
    {

        Ataque = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDeljugador);

        Detencion = Physics.CheckSphere(transform.position, rangoDeDetencion, capaDeljugador);


        if (Detencion == false && Ataque == false)
        {
            Patroling();

        }


        if (Detencion == true && Ataque == false)
        {
            patroling = false;

            Detectado();
        }

        if (Ataque == true)
        {
            Atacando();


        }






        //print(Ataque);


    }

    // public void ChangeState(bool patro, bool deten, bool atack)
    // {
    //     if(deten, atack)
    //     {
    //         patroling == true

    //     }
    //     if(deten, atack!)
    //     {
    //         patroling == true

    //     }

    // }


    public void Patroling()
    {

        
            float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

            if (TreshHold > distanceToTarget)
            {
                increseTargetInt();

                rangoDeAtaque = 6f;
                rangoDeDetencion = 20f;



                  

                ChangeDone = false;
                
                //rangoDeAtaque = Mathf.Lerp( 0f, 6f , 1f * Time.deltaTime);
                //rangoDeDetencion = Mathf.Lerp(0f, 20f , 1f * Time.deltaTime);

           

            }

            if(patroling == true)
            {
                //print(rangoDeAtaque);

                 //currentTime += Time.deltaTime;

                 //float t = Mathf.Clamp01(currentTime / 4f);
                
                 //rangoDeAtaque = Mathf.SmoothStep(0f, 6f, t);
                 //rangoDeDetencion = Mathf.SmoothStep(0f, 20f, t);

                 
            }

            

            

            

            


           


            // rangoDeAtaque = SmoothedAttack;
            // rangoDeDetencion =SmoothedDeten;

         

            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

            Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }





        


    }

    public float currentTime;

    public void Detectado()
    {

        if (Detencion == true && Ataque == false && AttackDone == false)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            Vector3 newPosition = target.transform.position - direction * distanceToPlayer;


            patroling = false;

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position * distanceToPlayer, speed * Time.deltaTime);




        }

    }

    public bool ChangeDone;

    public void ChangeState()
    {
        if (ChangeDone == false)
        {
            rangoDeAtaque = 0f;
            rangoDeDetencion = 0f;

            patroling = true;

            
            ChangeDone = true;
            GameManager.Instance.DisminuirNivelDeCarga();


        }


    }

    public void Atacando()
    {
        if (Ataque == true)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            Invoke("ChangeState", 1.0f);

             currentTime = 0f;





        }

    }

    private bool Atacado;


    public float distanceToPlayer;


    void increseTargetInt()
    {
        targetPoint++;
        //print("cambio de punto");
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }


    }

    public float rangoDeAtaque;
    public float rangoDeDetencion;

    public float rangoDeOlividar;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeDetencion);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(InicialPoistion, rangoDeOlividar);

    }

    // private bool Atacando;

    // private void OnTriggerEnter(Collider other) {

    //     if(other.CompareTag("Player"))
    //     {
    //         Atacando = true;
    //         print("atacando");

    //     }
    // }
    //  private void OnTriggerExit(Collider other) {

    //     if(other.CompareTag("Player"))
    //     {
    //         Atacando = false;

    //         print("no estoy atacando");

    //     }
    // }
}
