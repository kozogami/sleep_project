using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    float angle;
    float increment;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        increment = 0.5f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && angle < 1.5)
        {

            angle += increment * 1 * Time.deltaTime;

            Debug.Log("Current value: " + angle);
        }

        else if (!Input.GetKey(KeyCode.Space) && angle > 0) {

            angle -= 0.1f * 1 * Time.deltaTime;
        }

        animator.SetFloat("SpacePress", angle);



    }
}
