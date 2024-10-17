using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{

    // This object could be anything in the game, as shown in the inspector
    public GameObject musicBox;
    public GameObject testSource;
    public GameObject cuteMusicBox;
    public GameObject LightControl;
    public GameObject LightControlF;
    public GameObject locker;
    public GameObject endLock;


    bool music;
    bool music2;
    float angle;
    float increment;
    Animator animator;
    AudioSource mainAudio; // init audio source
    AudioSource secondaryAudio;

    /** @TOREAD 
     * 
     * Start is called before the first frame update.
     * 
     * Awake is when the object is appeared, it will be called,
     * which is faster than the start(), and better for init any values.
     * 
     */
    void Awake()
    {
        music = false;
        music2 = false;
        angle = 0;
        increment = 10f; // increasement rate
        animator = GetComponent<Animator>();
        //processBar.SetMax(100);


        if (musicBox != null && testSource != null) // If the source is not null, then play gives the value to the main audio.
        {

            music2 = true;
            music = true;

            mainAudio = musicBox.GetComponent<AudioSource>();
            Debug.Log("Audio loaded.");
            secondaryAudio = testSource.GetComponent<AudioSource>();
            Debug.Log("Secondary audio loaded.");
        }
        else
        {

            Debug.LogError("Error: Audio not loaded");
        }
    
    }
    /** @TOREAD 
     * 
     * Update is called once per frame
     * which means if the frame is 30, it will update 30 times in a frame. If it is 60 fps, then 60 times. 120 fps, 120 times.
     * 
     * FixedUpdate will not effected by frames, the default is 50/frame
     * use this for Update logic.
     */
    void Update()
    {


        if (!locker.activeInHierarchy)
        {
            musicBox.SetActive(true);
            testSource.SetActive(true);
            cuteMusicBox.SetActive(false);
            LightControl.SetActive(true);
            LightControlF.SetActive(false);

        }
        else if (endLock.activeInHierarchy)
        {

            LightControl.SetActive(false);
            LightControlF.SetActive(true);
            return;
        }





        //Debug.Log("Locker = " + locker.activeInHierarchy);

        //for now I'm just assigning a button to test toggling other music tracks on and off
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            secondaryAudio.mute = !secondaryAudio.mute;
        }
        if (Input.GetKey(KeyCode.Space) && angle < 120)
        { // If the spacebar was pressed, and the angle was less than 1.5, do the things listed below


            angle += increment * 1 * Time.deltaTime; // Angle increment, with a fixed time.

            //call fadeAudio class to (hopefully) smoothly transition between lower and higher volumes
            //it takes the arguments (audio source, duration of transition, target volume)
            StartCoroutine(FadeAudioSource.StartFade(mainAudio, 0.75f, 1.0f));
            StartCoroutine(FadeAudioSource.StartFade(secondaryAudio, 0.75f, 1.0f));

            //Debug.Log("Current value: " + angle);
        }

        else if (!Input.GetKey(KeyCode.Space) && angle > 0)
        { //Make sure the angle does not go negative, and pause the music when the spacebar is not being pressed




            angle -= increment * 1 * Time.deltaTime;

            if (music) StartCoroutine(FadeAudioSource.StartFade(mainAudio, 0.75f, 0.25f));
            if (music2) StartCoroutine(FadeAudioSource.StartFade(secondaryAudio, 0.75f, 0.25f));
        }

        animator.SetFloat("Position", angle);// update the angle to the unity



    }
}
