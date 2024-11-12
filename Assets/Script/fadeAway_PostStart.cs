using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class fadeAway_PostStart : MonoBehaviour
{
    
    public UnityEngine.UI.Slider slider;


    public GameObject endPanel;
    public GameObject[] lightObjects;
    private SpriteRenderer[] lightRenderer;

    private int dot;
    private int lastReached;
    private Color fullLight;

    private float countdownTime = 3f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        dot = 0;
        lastReached = 0;
        fullLight = new Color(1f, 1f, 1f, 1f);


        lightRenderer = new SpriteRenderer[24];
        for (int i = 0; i < lightRenderer.Length; i++)
        {
            lightRenderer[i] = lightObjects[i].GetComponent<SpriteRenderer>();
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (endPanel.activeInHierarchy) {

            for (int i = 0; i < lightRenderer.Length; i++)
            {

                lightRenderer[i].color = new Color(1.0f, 1.0f, 1.0f, 0f);

            }
            return;
        }


        dot = Mathf.Clamp(Mathf.FloorToInt(slider.value / 80f * 24f), 0, 23);

        if (dot > lastReached)
        {

            lastReached = dot;
            currentTime = countdownTime;
        }
  
        
        
        if (currentTime > 0)
        {

            currentTime -= Time.deltaTime;
          
        }
        else
        {
            if(lastReached > 0)
                lastReached--;


            currentTime = countdownTime;
        }


        for (int i = 0; i < lastReached + 1; i++) {

            if(lightRenderer[i].color.a > 0 ) {

                lightRenderer[i].color = new Color (1.0f,1.0f,1.0f, lightRenderer[i].color.a - 0.035f);

            } 
                   

        }

        //Debug.Log("Last: "+ lastReached);

        if(slider.value > 0.3f)
            lightRenderer[dot].color = fullLight;

    }
}
