using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SkewerController : MonoBehaviour
{
    float speed = 3.5f;
    int numOfSkewerFruits = 0;
    string[] fruitsList = new string[3];
    GameObject[] skeweredFruits = new GameObject[10];

    public SkewerFruitController[] skewerFruitControllers = new SkewerFruitController[3];

    SkewerFruitController[] fruitControllers;

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

    public void CountFruits(string fruitTag, GameObject skeweredFruit)
    {
        skewerFruitControllers[numOfSkewerFruits] = skeweredFruit.GetComponent<SkewerFruitController>();
        print(numOfSkewerFruits + ", " + skeweredFruit.name);
        numOfSkewerFruits++;

        if (numOfSkewerFruits == 3)
        {
            for (int i = 0; i < skewerFruitControllers.Length; i++)
            {
                skewerFruitControllers[i].DestroyFruit();
            }

            numOfSkewerFruits = 0;
        }


        //if (numOfSkewerFruits < 2)
        //{
        //    print(numOfSkewerFruits++ + ", " + fruitTag);
        //    skeweredFruits[numOfSkewerFruits] = skeweredFruit;
        //}
        //else if (numOfSkewerFruits == 2)
        //{
        //    print(numOfSkewerFruits++ + ", " + fruitTag);
        //    skeweredFruits[numOfSkewerFruits] = skeweredFruit;
        //    for (int i = 0; i <= skeweredFruits.Length; i++)
        //    {
        //        Destroy(skeweredFruits[i]);
        //        numOfSkewerFruits = 0;
        //    }
        //}
    }
}
