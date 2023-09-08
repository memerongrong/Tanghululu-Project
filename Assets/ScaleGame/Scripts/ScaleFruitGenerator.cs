using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFruitGenerator : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject[] spawner;

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
        Instantiate(fruit1, spawner[8].transform.position, fruit1.transform.rotation);
        numOfFruits--;

        // 1���� �� ��° ���� ����
        Instantiate(fruit2, spawner[7].transform.position, fruit2.transform.rotation);
        numOfFruits--;

        // ������ ���� ����
        for (int i = 0; i < numOfFruits; i++)
        {
            int index = Random.Range(0, 2);
            if (index == 0)
                Instantiate(fruit1, spawner[i].transform.position, fruit1.transform.rotation);
            else
                Instantiate(fruit2, spawner[i].transform.position, fruit2.transform.rotation);
        }
    }
}
