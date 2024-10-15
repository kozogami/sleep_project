using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ProcessBar : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;
    public float currentValue;
    public float maxValue;
    public float gameprogess;
    public float gameprogessSwitch;

    private float increment;



    void Awake()
    {
        slider.maxValue = 100;
        slider.value = 0;

        gameprogess = 0;
        gameprogessSwitch = 0;


        increment = 8.5f;




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


        if (Input.GetKey(KeyCode.Space)){

            slider.value += increment * 1 * Time.deltaTime;

        }

        else if (!Input.GetKey(KeyCode.Space) && slider.value > 0)
        {

            slider.value -= increment * 1 * Time.deltaTime;

        }




    }



}
