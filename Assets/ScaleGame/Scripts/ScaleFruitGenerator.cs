using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFruitGenerator : MonoBehaviour
{
    public GameObject[] fruits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    // 시작 버튼에 연결된 메서드
    // 시작 버튼을 누르면 게임이 시작된다.
    public void InstantiateFruits(GameObject fruit1, GameObject fruit2)
    {
        int numOfFruits;
        do
        {
            numOfFruits = Random.Range(3, 10);
        } while (numOfFruits % 2 == 0);

        print(numOfFruits);

        // 1개의 첫 번째 과일 생성
        Instantiate(fruit1);
        numOfFruits--;

        // 1개의 두 번째 과일 생성
        Instantiate(fruit2);
        numOfFruits--;

        // 나머지 과일 생성
        for (int i = 0; i < numOfFruits; i++)
        {
            int index = Random.Range(0, 2);
            if (index == 0)
                Instantiate(fruit1);
            else
                Instantiate(fruit2);
        }
    }
}
