using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightControl : MonoBehaviour
{

    public GameObject lightObject1;
    public GameObject lightObject2;
    public GameObject lightObject3;
    public GameObject lightObject4;
    public GameObject lightObject5;
    public GameObject lightObject6;
    public GameObject lightObject7;
    public GameObject lightObject8;
    public GameObject locker;
    public GameObject endLock;

    private System.Random random;
    public int randomNumber;

    SpriteRenderer[] lightRenderer;


    private bool isOn;
    private bool stopTheLoop;
    private float timer = 0f;
    public float waitTime = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        random = new System.Random();
        randomNumber = 0;

        lightRenderer = new SpriteRenderer[8];

        isOn = false;
        stopTheLoop = true;

        lightRenderer[0] = lightObject1.GetComponent<SpriteRenderer>();
        lightRenderer[1] = lightObject2.GetComponent<SpriteRenderer>();
        lightRenderer[2] = lightObject3.GetComponent<SpriteRenderer>();
        lightRenderer[3] = lightObject4.GetComponent<SpriteRenderer>();
        lightRenderer[4] = lightObject5.GetComponent<SpriteRenderer>();
        lightRenderer[5] = lightObject6.GetComponent<SpriteRenderer>();
        lightRenderer[6] = lightObject7.GetComponent<SpriteRenderer>();
        lightRenderer[7] = lightObject8.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

        if (endLock.activeInHierarchy && stopTheLoop) {

            Debug.Log("Act--------------------------");
            for (int i = 0; i < lightRenderer.Length; i++)
                lightRenderer[i].enabled = false;

            stopTheLoop = false;

        }else if (endLock.activeInHierarchy && !stopTheLoop) {

            return;
        }


        if (!locker.activeInHierarchy)
        {
            timer += Time.deltaTime;


            if (timer >= waitTime)
            {
                isOn = true;
                //Debug.Log("Light " + randomNumber + " is ON");

                randomNumber = random.Next(1, 9);
                StartCoroutine(ControlLights(randomNumber));

                timer = 0f;
                isOn = false;
                //Debug.Log("Light " + randomNumber + " is OFF");
            }
        }
    }



    IEnumerator ControlLights(int randomNumber)
    {

        //Debug.Log("Light Switch: " + randomNumber);


        Renderer selectedLight = lightRenderer[randomNumber - 1];
        if (selectedLight != null)
        {
            selectedLight.enabled = true;

            //Debug.Log("Light " + randomNumber + " is ON");


            yield return new WaitForSeconds(10);
            selectedLight.enabled = false;
            //Debug.Log("Light " + randomNumber + " is OFF");
        }

    }


    public int getRandomNumber() {

        return randomNumber;

    }

    public bool IsLightOn()
    {

        return isOn;

    }


}
