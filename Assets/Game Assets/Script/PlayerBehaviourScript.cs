using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject musicBox;

    bool music;
    bool musicPlayed;
    float angle;
    float increment;
    Animator animator;
    AudioSource mainAudio;

    // Start is called before the first frame update
    void Start()
    {
        music = false;
        musicPlayed = false;
        angle = 0;
        increment = 0.5f;
        animator = GetComponent<Animator>();


        if (musicBox != null)
        {

            music = true;
            mainAudio = musicBox.GetComponent<AudioSource>();
            Debug.Log("Audio loaded.");
        }
        else {


            Debug.LogError("Error at line -> 33");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && angle < 1.5) {


            angle += increment * 1 * Time.deltaTime;

            if (music && !musicPlayed)
            {

                musicPlayed = true;
                mainAudio.Play();

            } else {


                mainAudio.UnPause();
            }

            Debug.Log("Current value: " + angle);
        }

        else if (!Input.GetKey(KeyCode.Space) && angle > 0) {



            angle -= 0.1f * 1 * Time.deltaTime;

            if (music) mainAudio.Pause();
        }

        animator.SetFloat("SpacePress", angle);



    }
}
