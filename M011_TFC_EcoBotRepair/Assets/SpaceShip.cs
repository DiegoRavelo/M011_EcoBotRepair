using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;

    public GameObject main25;

    void Start()
    {
        Invoke("Animation", 10f);

        main25.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Animation()
    {
        anim1.Play("DoorLEFT");
        anim2.Play("DoorRIGHT");
        anim3.Play("DoorDOWN");

        main25.SetActive(true);

    }
}
