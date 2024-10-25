using System;
using UnityEngine;


public class ProcessBar : MonoBehaviour
{

    public UnityEngine.UI.Slider slider;


    int dot;
    public float gameprogess;
    public float gameprogessSwitch;
    private float increment;
    private bool isStarted;


    public GameObject startPanel;
    public GameObject endPanel;
    public SpriteRenderer[] lightRenderer;

    void Awake()
    {
        dot = 0;
        slider.maxValue = 80;
        slider.value = 0;
        increment = 7f;

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

        if (isStarted && slider.value > 0.3f) {


            dot = Mathf.FloorToInt(slider.value / 80f * 24f);

            lightRenderer[dot].color = new Color(1f, 1f, 1f, 1.0f);


        }






        if (!isStarted && Input.GetKey(KeyCode.Space)) {//unlock the screen


            startPanel.SetActive(false);
            isStarted = true;

        }

    }

}
