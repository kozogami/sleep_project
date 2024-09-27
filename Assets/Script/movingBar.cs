using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class movingBar : MonoBehaviour
{

    Rigidbody2D rigi;
    public float movingSpeed;

    // Start is called before the first frame update
    void Awake()
    {

        rigi = GetComponent<Rigidbody2D>();
        Debug.Log("Moving bar loaded.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.Space))
        {



            rigi.AddForce(Vector2.up * movingSpeed, ForceMode2D.Force);
        }



    }
}
