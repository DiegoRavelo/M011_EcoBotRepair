using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sabrina : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    
    private float vidaSabrina;

    public Slider slidersabrina;

    public float speed;

    

    void Start()
    {
        vidaSabrina = 0;

        speed = 1f;

        

        
    }

    // Update is called once per frame
    void Update()
    {
        slidersabrina.value = vidaSabrina;

        vidaSabrina += speed * Time.deltaTime;
        
    }
}
