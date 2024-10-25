using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeAway : MonoBehaviour
{

    private bool isWaiting = false;
    private float countdown = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();


        Color currentColor = renderer.material.color;

        // 检查是否达到 Alpha 为 1.0f
        if (currentColor.a >= 1.0f && !isWaiting)
        {
            // 开始倒计时并设置等待状态
            isWaiting = true;
            countdown = 1.0f;
        }

        // 如果在等待中，开始倒计时
        if (isWaiting)
        {
            countdown -= Time.deltaTime;  // 倒计时减少

            // 当倒计时结束后，开始减少 Alpha 值
            if (countdown <= 0f)
            {
                isWaiting = false;  // 倒计时结束，结束等待状态
            }
        }
        else
        {
            // 倒计时结束后开始减少 Alpha 值
            currentColor.a -= Time.deltaTime * 0.1f;  // 0.1f 是速度因子，可根据需要调整

            // 确保 Alpha 值不会低于 0
            currentColor.a = Mathf.Clamp(currentColor.a, 0f, 1f);

            // 重新设置修改后的颜色
            renderer.material.color = currentColor;
        }
        }
    }
