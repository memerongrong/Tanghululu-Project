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


    // ���� ��ư�� ����� �޼���
    // ���� ��ư�� ������ ������ ���۵ȴ�.
    public void InstantiateFruits(GameObject fruit1, GameObject fruit2)
    {
        int numOfFruits;
        do
        {
            numOfFruits = Random.Range(3, 10);
        } while (numOfFruits % 2 == 0);

        print(numOfFruits);

        // 1���� ù ��° ���� ����
        Instantiate(fruit1);
        numOfFruits--;

        // 1���� �� ��° ���� ����
        Instantiate(fruit2);
        numOfFruits--;

        // ������ ���� ����
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
