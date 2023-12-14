using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatBattery : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject battery;

    public Transform[] patrolPoints;

    public int targetPoint;

    public float speed;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(battery.activeSelf)
        {
            float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

             if (distanceToTarget < 1f)
            {
               

                 targetPoint += 1;
                 
                 if(targetPoint >= patrolPoints.Length)
                 {
                    targetPoint = 0;
                 }
             }

        }
        
    }
}
