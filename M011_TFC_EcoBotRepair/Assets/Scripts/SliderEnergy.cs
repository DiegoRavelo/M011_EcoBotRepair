using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderEnergy : MonoBehaviour
{
    public Slider slider;

    public float lerpSpeed = 4.0f; // Ajusta la velocidad de interpolación según tus preferencias

    private int targetValue;

    public TMP_Text tuercas;

    public TMP_Text muelle;

    public TMP_Text engranje;

    
    void Start()
    {
         //targetValue = GameManager.Instance.NivelDeCarga + 1;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.NivelDeCarga == 1)
        {
            slider.value = 1f;

        }

         if(GameManager.Instance.NivelDeCarga == 2)
        {
            slider.value = 2.24f;

        }
         if(GameManager.Instance.NivelDeCarga == 3)
        {
            slider.value = 3.47f;

        }
         if(GameManager.Instance.NivelDeCarga == 4)
        {
            slider.value = 5;

        }


        tuercas.text = GameManager.Instance.TuercaTotal.ToString();

        muelle.text = GameManager.Instance.MuelleTotal.ToString();

        engranje.text = GameManager.Instance.MetalTotal.ToString();


        // // Actualiza el valor objetivo si ha cambiado
        // int newValue = GameManager.Instance.NivelDeCarga + 1;
        // if (newValue != targetValue)
        // {
        //     targetValue = newValue;
        // }

        // // Interpola suavemente hacia el valor objetivo
        // sliderValue = Mathf.Lerp(sliderValue, targetValue, lerpSpeed * Time.deltaTime);

        // // Asigna el valor interpolado al Slider
        // slider.value = sliderValue;
    }
}
