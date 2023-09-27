using UnityEngine;

public class BasketFruitGenerator : MonoBehaviour
{
    public GameObject[] fruits;
    int kindOfFruits;
    float span = 1.8f;
    float delta = 0.0f;
        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //���� �ð��� ���� ������ ������ ������ ��ġ�� �����ǵ��� ����
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0.0f;

            int kind = Random.Range(0, kindOfFruits);
            int randomPositionX = Random.Range(-1, 2);
            int randomPositionY = Random.Range(-1, 2);

            Instantiate(fruits[kind], new Vector3 (randomPositionX, 5, randomPositionY), fruits[kind].transform.rotation);
            print(new Vector3(randomPositionX, 3, randomPositionY));
        }
    }

    //������ �޼���
    public void LevelDesign(int newNumber)
    {
        kindOfFruits = newNumber;
    }
}
