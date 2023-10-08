using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEnergy : MonoBehaviour
{
    public Slider slider;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int value = GameManager.Instance.NivelDeCarga + 1;

        slider.value = value;
    }
}
