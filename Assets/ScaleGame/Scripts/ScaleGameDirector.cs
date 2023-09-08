
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScaleGameDirector : MonoBehaviour
{
    ScaleFruitGenerator fruitGenerator;
    SeeSawController seeSaw;

    GameObject blueScore;
    GameObject redScore;
    GameObject inequalitySign;
    GameObject[] gameFruits;
    GameObject[] apples;
    GameObject[] cherries;
    GameObject[] watermelons;
    GameObject[] lemons;
    GameObject[] strawberries;

    int blue = 0;
    int red = 0;

    Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        fruitGenerator = GameObject.Find("FruitGenerator").GetComponent<ScaleFruitGenerator>();
        seeSaw = GameObject.Find("SeeSaw").GetComponent<SeeSawController>();

        blueScore = GameObject.Find("BlueScore");
        redScore = GameObject.Find("RedScore");
        inequalitySign = GameObject.Find("InequalitySign");
    }

    // Update is called once per frame
    void Update()
    {
        apples = GameObject.FindGameObjectsWithTag("Apple");
        cherries = GameObject.FindGameObjectsWithTag("Cherries");
        watermelons = GameObject.FindGameObjectsWithTag("Watermelon");
        lemons = GameObject.FindGameObjectsWithTag("Lemon");
        strawberries = GameObject.FindGameObjectsWithTag("Strawberry");

        gameFruits = apples.Concat(cherries)
                         .Concat(watermelons)
                         .Concat(lemons)
                         .Concat(strawberries)
                         .ToArray();

        redScore.GetComponent<Text>().text = red.ToString();
        blueScore.GetComponent<Text>().text = blue.ToString();

        if (blue > red)
            inequalitySign.GetComponent<Text>().text = ">";
        if (blue == red)
            inequalitySign.GetComponent<Text>().text = "=";
        if (blue < red)
            inequalitySign.GetComponent<Text>().text = "<";
    }

    public void Count(string plateColor)
    {
        if (plateColor == "Red") red++;
        if (plateColor == "Blue") blue++;
    }

    public void StartGame()
    {
        GameObject[] fruits = fruitGenerator.fruits;
        int index1 = Random.Range(0, fruits.Length);
        int index2 = Random.Range(0, fruits.Length);

        if (index1 == index2)
            index2 = Random.Range(0, fruits.Length);

        if (index1 != index2)
        {
            seeSaw.PlateSetting(fruits[index1].gameObject.tag, fruits[index2].gameObject.tag);
            Debug.Log("Blue: " + fruits[index1].gameObject.tag + ", Red: " + fruits[index2].gameObject.tag);
        }

        //기존 과일 삭제
        foreach (GameObject gameFruit in gameFruits)
        {
            Destroy(gameFruit);
            print("과일 삭제");
        }

        //점수 리셋
        blue = 0;
        red = 0;

        //과일 생성
        fruitGenerator.InstantiateFruits(fruits[index1], fruits[index2]);
    }
}
