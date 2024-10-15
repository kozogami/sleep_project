using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLight : MonoBehaviour
{
    Animator animator;
    private int Progess_for_light ;


    void Awake()
    {

        animator = GetComponent<Animator>();
        Progess_for_light = 0;


        if (animator != null)
        {

            Debug.Log("TopLight loaded.");
        }
        else
        {

            Debug.LogError("Error: TopLight not loaded");
        }

    }

    void Update()
    {


        animator.SetInteger("Progess", Progess_for_light);
    }





   
}
