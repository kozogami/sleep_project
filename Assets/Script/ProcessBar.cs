using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopLight : MonoBehaviour
{

    public UnityEngine.UI.Slider thatSlider;
    public UnityEngine.UI.Slider thisSlider;
    public GameObject objectMask;
    public GameObject roomMask;
    public GameObject EndScreen;
    public Image roomMaskImage;
    public Image objectMaskImage;
    public float roomMaskMaxOpacity;
    public float objectMaskMaxOpacity;
    public bool readyForNext;
    private int currentSceneIndex;

    public GameObject[] lightObjects;
    private SpriteRenderer[] lightRenderer;


    
    private float increment;
    private float lightPos;

    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        increment = 7f;

        roomMaskImage = roomMask.GetComponent<Image>();
        objectMaskImage = objectMask.GetComponent<Image>();


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

        
        var tempColorRoom = roomMaskImage.color;
        tempColorRoom.a = thisSlider.value/100;
        if (tempColorRoom.a > roomMaskMaxOpacity)
        {
            tempColorRoom.a = roomMaskMaxOpacity;
        }
        roomMaskImage.color = tempColorRoom;

        var tempColorObject = objectMaskImage.color;
        tempColorObject.a = thisSlider.value/100;
        if (tempColorObject.a > objectMaskMaxOpacity)
        {
            tempColorObject.a = objectMaskMaxOpacity;
        }
        objectMaskImage.color = tempColorObject;

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

        if (readyForNext)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(currentSceneIndex+1);
            }
        }

    }



    public void Pause()
    {
        thatSlider.value = 80;
        EndScreen.SetActive(true);
        readyForNext = true;


        //Time.timeScale = 0.3f;
        //AudioListener.pause = true;  // stop Audio
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;  // start Audio
    }




}
