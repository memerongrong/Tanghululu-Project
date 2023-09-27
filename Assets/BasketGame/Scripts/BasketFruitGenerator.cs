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

        //일정 시간에 따라 랜덤한 과일이 랜덤한 위치에 생성되도록 설정
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

    //레벨링 메서드
    public void LevelDesign(int newNumber)
    {
        kindOfFruits = newNumber;
    }
}
