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

    private float lastValue;
    private float countDown; // in frame


/*    public GameObject lightObject0;
    public GameObject lightObject1;
    public GameObject lightObject2;
    public GameObject lightObject3;
    public GameObject lightObject4;


    SpriteRenderer lightRenderer0;
    SpriteRenderer lightRenderer1;
    SpriteRenderer lightRenderer2;
    SpriteRenderer lightRenderer3;
    SpriteRenderer lightRenderer4;*/


    void Awake()
    {
        slider.maxValue = 100;
        slider.value = 0;
        lastValue = 0;
        countDown = 300;
        gameprogess = 0;
        gameprogessSwitch = 0;

/*        lightRenderer0 = lightObject0.GetComponent<SpriteRenderer>();
        lightRenderer1 = lightObject1.GetComponent<SpriteRenderer>();
        lightRenderer2 = lightObject2.GetComponent<SpriteRenderer>();
        lightRenderer3 = lightObject3.GetComponent<SpriteRenderer>();
        lightRenderer4 = lightObject4.GetComponent<SpriteRenderer>();*/


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

        if (slider.value % 20 >= 1 && slider.value > gameprogess) { 
        
            gameprogess += slider.value;
            Debug.Log("gameProgess: "+ gameprogess);
        }



        if (lastValue < slider.value) { 
            
            lastValue = slider.value;
            countDown = 300;
        
        } 
        else if (slider.value == lastValue && countDown > 0) {

            countDown--;
        }
        else if (slider.value == lastValue && countDown == 0 && slider.value >= gameprogess)
        {

            slider.value -= 0.05f;
            lastValue = slider.value;
        }



        // turn off the light

        gameprogessSwitch = gameprogess % 20;
        Debug.Log("gameProgess Switch: " + gameprogessSwitch + "---- gameProgess: " + gameprogess);


/*        if (gameprogessSwitch > 1 && gameprogessSwitch < 2) {

            if (lightRenderer0 != null)
            {
                lightRenderer0.enabled = false;
            }
        }

        else if (gameprogessSwitch > 2 && gameprogessSwitch < 3)
        {
            if (lightRenderer1 != null)
            {
                lightRenderer1.enabled = false;
            }
        }

        else if (gameprogessSwitch > 3 && gameprogessSwitch < 4)
        {
            if (lightRenderer2 != null)
            {
                lightRenderer2.enabled = false;
            }
        }

        else if (gameprogessSwitch > 4 && gameprogessSwitch < 5)
        {
            if (lightRenderer3 != null)
            {
                lightRenderer3.enabled = false;
            }
        }

        else if (gameprogessSwitch > 5 && gameprogessSwitch < 6)
        {
            if (lightRenderer4 != null)
            {
                lightRenderer4.enabled = false;
            }
        }*/


    }



}
