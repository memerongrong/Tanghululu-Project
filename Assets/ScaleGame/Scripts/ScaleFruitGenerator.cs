using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFruitGenerator : MonoBehaviour
{
    ScaleGameDirector gameDirector;

    public GameObject[] fruits;
    public GameObject[] spawner;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<ScaleGameDirector>();
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

        gameDirector.CountFruits(numOfFruits);

        // 1개의 첫 번째 과일 생성
        Instantiate(fruit1, spawner[8].transform.position, fruit1.transform.rotation);
        numOfFruits--;

        // 1개의 두 번째 과일 생성
        Instantiate(fruit2, spawner[7].transform.position, fruit2.transform.rotation);
        numOfFruits--;

        // 나머지 과일 생성
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
