using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLight : MonoBehaviour
{

    public UnityEngine.UI.Slider thatSlider;
    public UnityEngine.UI.Slider thisSlider;
    public GameObject EndScreen;


    public GameObject[] lightObjects;
    private SpriteRenderer[] lightRenderer;


    
    private float increment;
    private float lightPos;

    void Awake()
    {


        increment = 7f;



        lightRenderer = new SpriteRenderer[8];
        for (int i = 0; i < lightObjects.Length; i++) {
            lightRenderer[i] = lightObjects[i].GetComponent<SpriteRenderer>();
        }


        if (thatSlider != null && thisSlider != null)
        {

            Debug.Log("ProcessBar loaded.");
        }
        else
        {

            Debug.LogError("Error: ProcessBar not loaded");
        }

    }

    void Update()
    {
        if (thisSlider.value >= 79.8f) {

            Pause();
        }



        for (int i = 0; i < lightObjects.Length; i++)
        {
        
            if (lightRenderer[i].isVisible)
            {
                lightPos = i + 1;
                break;
            }
        }


        if ((thatSlider.value >= (lightPos * 10 - 10) + 0.1f) && thatSlider.value < lightPos * 10)
        {
            thisSlider.value += increment * Time.deltaTime;
        }

        //Debug.Log("lightPos = "+ lightPos + " thatSlider.value = " + thatSlider.value);
        lightPos = 0;

    }



    public void Pause()
    {
        EndScreen.SetActive(true);


        Time.timeScale = 0.3f;
        AudioListener.pause = true;  // stop Audio
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;  // start Audio
    }




}
