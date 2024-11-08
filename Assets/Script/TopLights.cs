using System;
using Unity.VisualScripting;
using UnityEngine;


public class ProcessBar : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;


    private int dot;
    public float gameprogess;
    public float gameprogessSwitch;

    private float increment;
    private bool isStarted;

    public GameObject FrontVideo;
    public GameObject startPanel;
    public GameObject endPanel;

    public GameObject[] lightObjects;

    private SpriteRenderer[] lightRenderer;

    void Awake()
    {
        dot = 0;
        slider.maxValue = 80;
        slider.value = 0;
        increment = 7f;  // slider increas speed ***

        gameprogess = 0;
        gameprogessSwitch = 0;


        isStarted = false;


        if (slider != null)
        {

            Debug.Log("TopLight in place.");
        }
        else
        {

            Debug.LogError("Error: Process Bar");
        }

        lightRenderer = new SpriteRenderer[24];
        for (int i = 0; i < lightRenderer.Length; i++) {
            lightRenderer[i] = lightObjects[i].GetComponent<SpriteRenderer>();
        }


}

    private void FixedUpdate()
    {

        if (endPanel.activeInHierarchy) {//end game
            isStarted = false;
            return;
        }



        if (Input.GetKey(KeyCode.Space) && isStarted){

            slider.value += increment * 1 * Time.deltaTime;

        }

        else if (!Input.GetKey(KeyCode.Space) && slider.value > 0)
        {

            slider.value -= increment * 1 * Time.deltaTime;

        }


        if (isStarted && slider.value > 0.3f)
        {
            dot = Mathf.Clamp(Mathf.FloorToInt(slider.value / 80f * 24f), 0, 23);

            lightRenderer[dot].color = new Color(1f, 1f, 1f, 1f);
            //Debug.Log("Dot: " + dot);
           
        }




        if (!isStarted && Input.GetKey(KeyCode.Space)) {//unlock the screen


            startPanel.SetActive(false);
            FrontVideo.SetActive(false);
            isStarted = true;

        }

    }

}
