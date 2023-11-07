using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryChange : MonoBehaviour
{


    // public Material batteryMaterial;

    public Material[] MaterialsToChange;

    public Material[] MaterialsToChangeFace;

    private Renderer rend;

    void Start() {

        rend = GetComponent<Renderer>();
        

        
    }


    // Update is called once per frame
    void Update()
    {
      
        ChangeTexture();


    }


    public void ChangeTexture()
    {
        int charge;

        charge = GameManager.Instance.NivelDeCarga;

        Material[] materials = rend.materials;


        materials[1] = MaterialsToChange[charge - 1];

        materials[0] = MaterialsToChangeFace[charge - 1];

        rend.materials = materials;



        
    }
}
