using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class correctAreaMoving : MonoBehaviour
{
    public Slider slider;
    public float movingSpeed;
    public float moveInterval;

    private Vector3 originPosition;
    private Vector3 targetPosition;
    private System.Random random;
    private float timeSinceLastMove = 0f;
    private float lerpProgress = 0f; // lerp control

    private bool isMoving = false; //is moving or not

    void Awake()
    {
        random = new System.Random();
        originPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);

        if (slider == null) // auto find
        {
            slider = FindObjectOfType<Slider>();
        }
    }

    void FixedUpdate()
    {
        timeSinceLastMove += Time.deltaTime;

        
        if (timeSinceLastMove >= moveInterval && !isMoving)
        {
            timeSinceLastMove = 0f;

            
            double nextMoveDis = random.NextDouble() * (4 - (-4)) + (-4);



            // new target pos
            targetPosition = new Vector3(targetPosition.x, targetPosition.y + (float)nextMoveDis, targetPosition.z);

            // reset
            lerpProgress = 0f;
            isMoving = true;

            Debug.Log("MoveDis: " + nextMoveDis + " | MoveSpeed: " + movingSpeed);
        }


        if (isMoving)
        {
            lerpProgress += Time.deltaTime * movingSpeed;

 
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpProgress);

            if (lerpProgress >= 1f)
            {
                isMoving = false; 

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "movingBar")
        {
            slider.value += 0.15f;
        }
    }
}
