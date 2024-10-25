using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeAway : MonoBehaviour
{

    private new Renderer renderer; 


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("No Renderer found on this object!");
            return;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.material.color.a >= 0.0f)
        {


            Color newColor = renderer.material.color;
            newColor.a -= 0.0001f;  // 递减 alpha 值
            renderer.material.color = newColor;  // 重新赋值给材质

            Debug.Log("A: " + renderer.material.color.a);
        }


    }
    }
