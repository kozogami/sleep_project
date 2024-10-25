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

        // ����Ƿ�ﵽ Alpha Ϊ 1.0f
        if (currentColor.a >= 1.0f && !isWaiting)
        {
            // ��ʼ����ʱ�����õȴ�״̬
            isWaiting = true;
            countdown = 1.0f;
        }

        // ����ڵȴ��У���ʼ����ʱ
        if (isWaiting)
        {
            countdown -= Time.deltaTime;  // ����ʱ����

            // ������ʱ�����󣬿�ʼ���� Alpha ֵ
            if (countdown <= 0f)
            {
                isWaiting = false;  // ����ʱ�����������ȴ�״̬
            }
        }
        else
        {
            // ����ʱ������ʼ���� Alpha ֵ
            currentColor.a -= Time.deltaTime * 0.1f;  // 0.1f ���ٶ����ӣ��ɸ�����Ҫ����

            // ȷ�� Alpha ֵ������� 0
            currentColor.a = Mathf.Clamp(currentColor.a, 0f, 1f);

            // ���������޸ĺ����ɫ
            renderer.material.color = currentColor;
        }
        }
    }
