using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteContador : MonoBehaviour
{
    // Start is called before the first frame update
 

    private Image imageComponent;

    public UnityEngine.Sprite[] tilesCon;

    

    private void Start()
     {

         imageComponent = GetComponent<Image>();
    }

    private void Update() {
        
        imageComponent.sprite = tilesCon[total];

        ChangeTexture();
    }

    public string material;

    private int total;

    public void ChangeTexture()
    {
        if (material == "tuerca")
        {
            total = GameManager.Instance.TuercaTotal;

        }
         if(material == "muelle")
        {
            total = GameManager.Instance.MuelleTotal;
            
        }
         if(material == "metal")
        {
            total = GameManager.Instance.MetalTotal;
            
        }




    }
}


