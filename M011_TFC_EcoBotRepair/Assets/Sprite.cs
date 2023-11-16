using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sprite : MonoBehaviour
{



    private Image imageComponent;

    public UnityEngine.Sprite[] tiles;

    private void Start()
    {

        imageComponent = GetComponent<Image>();
        


    

        
        
    }

    private void Update()
    {
        ChangeTexture();

       
    }

    public void ChangeTexture()
    {
        int charge = GameManager.Instance.NivelDeCarga;

        imageComponent.sprite = tiles[charge -1];

    }

}
