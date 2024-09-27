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

    void Awake()
    {
        currentValue = 0;
        maxValue = 100;
        if (slider != null)
        {

            Debug.Log("Slider in place.");
        }
        else
        {

            Debug.LogError("Error: Process Bar");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentValue < 100)
        {


            currentValue +=  5.0f * Time.deltaTime; // Angle increment, with a fixed time.

            //Debug.Log("Current PB value: " + currentValue);
        }

        else if (!Input.GetKey(KeyCode.Space) && currentValue > 0)
        {


            currentValue -= 1 * Time.deltaTime;

        }


        slider.value = currentValue;

    }

    public void addValue(float newValue)
    {

        slider.value += newValue;
    }
    
}
