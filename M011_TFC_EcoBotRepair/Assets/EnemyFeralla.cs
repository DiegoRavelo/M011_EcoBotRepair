using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyFeralla : MonoBehaviour
{
      public float velocidad;

    private ParticleSystem sp1;
    private ParticleSystem sp2;

    public GameObject explosion;

    public GameObject[] pickups;

    public EnemyStatment estadoActual;

    
    [SerializeField]

    M011_PlayerController _playerController ;





    void Start()
    {
        velocidad = 12f;        

        _playerController = FindObjectOfType<M011_PlayerController>();

        StartCoroutine("Explosion");
        
    }

    public void CambiarEstado(EnemyStatment newstate)
    {
        estadoActual = newstate;
    }

    // Update is called once per frame
    void Update()
    {
        switch(estadoActual)
        {
             case EnemyStatment.Moving:

             transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

             break;

             case EnemyStatment.Explosion:

             

             transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

             StartCoroutine("CountDown");

             CambiarEstado(EnemyStatment.Waiting);

             break;

             case EnemyStatment.Waiting:

             DOTween.To(()=> velocidad, x=> velocidad = x, 0f, 1.5f);


             transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

             break;
        

        }

       

        
    }

    public IEnumerator Explosion()
    {
        int intervalo = Random.Range(4,6);

        yield return new WaitForSeconds(intervalo);

        CambiarEstado(EnemyStatment.Explosion);
        
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3f);

        Dead();
    }

    public void Dead()
    {
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(pickups[0], gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(pickups[1], gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(pickups[2], gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
             Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        

             _playerController.Killed();
             
             Destroy(gameObject);

             

        }
    }
   
}

// public enum EnemyStatment
// {
//     Moving,
//     Waiting,
//     Explosion
// }

