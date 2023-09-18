using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SkewerController : MonoBehaviour
{
    float speed = 3.5f;
    string[] fruitsList = new string[3];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SekwelControll();
    }

    void SekwelControll()
    {
        //��ġ�� �������� �����ϴ� �޼���
        //��ġ�� ������ �� X �Ӽ����� ���� �̵��� �����Ѵ�.
        float xPosition = this.transform.position.x;
        float maxMove = 3.5f;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (xPosition > -maxMove)
                transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (xPosition < maxMove)
                transform.Translate(speed, 0, 0);
        }
    }

    public void CountFruits(string fruitTag)
    {
        print(fruitTag);
    }
}
