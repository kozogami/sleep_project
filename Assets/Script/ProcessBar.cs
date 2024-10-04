using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ProcessBar : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;
    public float currentValue;
    public float maxValue;
    
    private float lastValue;
    private float countDown; // in frame

    void Awake()
    {
        slider.maxValue = 100;
        slider.value = 0;
        lastValue = 0;
        countDown = 300;


        if (slider != null)
        {

            Debug.Log("Slider in place.");
        }
        else
        {

            Debug.LogError("Error: Process Bar");
        }
    }

    private void FixedUpdate()
    {
        if (lastValue < slider.value) { 
            
            lastValue = slider.value;
            countDown = 300;
        
        } 
        else if (slider.value == lastValue && countDown > 0) {

            countDown--;
        }
        else if (slider.value == lastValue && countDown == 0 && slider.value >= 0.05)
        {

            slider.value -= 0.05f;
            lastValue = slider.value;
        }


    }



}
