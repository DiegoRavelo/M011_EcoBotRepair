using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSprint : MonoBehaviour
{
   

    [SerializeField]
    private Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.RemainingSprintTime;
        
    }
}
