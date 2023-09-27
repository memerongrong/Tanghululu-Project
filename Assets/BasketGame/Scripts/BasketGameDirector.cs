using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketGameDirector : MonoBehaviour
{
    BasketFruitGenerator fruitGenerator;
    int[] basketScoreArray = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        fruitGenerator = GameObject.Find("BasketFruitGenerator").GetComponent<BasketFruitGenerator>();

        //레벨링 메서드를 호출
        fruitGenerator.LevelDesign(5);

        //점수 배열 초기화
        for (int index = 0; index < basketScoreArray.Length; index++) 
        {
            basketScoreArray[index] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetFruit(string fruit)
    {
        if (fruit == "Apple")
        {
            basketScoreArray[0] += 1;
        }
        else if (fruit == "Cherries")
        {
            basketScoreArray[1] += 1;
        }
        else if (fruit == "Lemon")
        {
            basketScoreArray[2] += 1;
        }
        else if (fruit == "Strawberry")
        {
            basketScoreArray[3] += 1;
        }
        else if (fruit == "Watermelon")
        {
            basketScoreArray[4] += 1;
        }
        else print(fruit);

        print("Apple: " + basketScoreArray[0] + ", Cherries: " + basketScoreArray[1] + ", Lemon: " + basketScoreArray[2] + ", Strawberry: " + basketScoreArray[3] + ", Watermelon: " + basketScoreArray[4]);
    }

    public void Replay()
    {
        SceneManager.LoadScene("TitleScene");
    }    
}
