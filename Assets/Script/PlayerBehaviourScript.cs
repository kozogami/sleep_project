using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // This object could be anything in the game, as shown in the inspector
    public GameObject musicBox; 


    bool music;
    bool musicPlayed;
    float angle;
    float increment;
    Animator animator;
    AudioSource mainAudio; // init audio source

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
        musicPlayed = false;
        angle = 0;
        increment = 0.5f; // increasement rate
        animator = GetComponent<Animator>();


        if (musicBox != null) // If the source is not null, then play gives the value to the main audio.
        {

            music = true;
            mainAudio = musicBox.GetComponent<AudioSource>();
            Debug.Log("Audio loaded.");
        }
        else {


            Debug.LogError("Error at line -> 33");
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

        if (Input.GetKey(KeyCode.Space) && angle < 1.5)
        { // If the spacebar was pressed, and the angle was less than 1.5, do the things listed below


            angle += increment * 1 * Time.deltaTime; // Angle increment, with a fixed time.


            if (music && !musicPlayed)
            {//Check if the loading is correct. if the music was never played before, them play the music


                musicPlayed = true;
                mainAudio.Play();

            } else { // else unpause to continue to play


                mainAudio.UnPause();
            }

            Debug.Log("Current value: " + angle);
        }

        else if (!Input.GetKey(KeyCode.Space) && angle > 0)
        { //Make sure the angle does not go negative, and pause the music when the spacebar is not being pressed




            angle -= 0.1f * 1 * Time.deltaTime;

            if (music) mainAudio.Pause();
        }

        animator.SetFloat("SpacePress", angle);// update the angle to the unity



    }
}
