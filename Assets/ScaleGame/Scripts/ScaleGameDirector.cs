
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScaleGameDirector : MonoBehaviour
{
    public Sprite[] gameFruitImages;

    ScaleFruitGenerator fruitGenerator;
    SeeSawController seeSaw;

    Image redFruitImage;
    Image blueFruitImage;

    GameObject blueScore;
    GameObject redScore;
    GameObject inequalitySign;
    GameObject startButton;
    GameObject InGameUI;
    GameObject[] gameFruits;
    GameObject[] apples;
    GameObject[] cherries;
    GameObject[] watermelons;
    GameObject[] lemons;
    GameObject[] strawberries;

    int blue = 0;
    int red = 0;
    int allFruits;
    bool isStarted;

    Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        fruitGenerator = GameObject.Find("FruitGenerator").GetComponent<ScaleFruitGenerator>();
        seeSaw = GameObject.Find("SeeSaw").GetComponent<SeeSawController>();

        blueScore = GameObject.Find("BlueScore");
        redScore = GameObject.Find("RedScore");
        inequalitySign = GameObject.Find("InequalitySign");
        blueFruitImage = GameObject.Find("BlueFruitImage").GetComponent<Image>();
        redFruitImage = GameObject.Find("RedFruitImage").GetComponent<Image>();

        startButton = GameObject.Find("StartButton");
        InGameUI = GameObject.Find("InGameUI");
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

        if (blue + red == allFruits)
            isStarted = false;

        if (isStarted)
        {
            startButton.SetActive(false);
            InGameUI.SetActive(true);
        }
        if (!isStarted) 
        {
            startButton.SetActive(true);
            InGameUI.SetActive(false);
        }
    }

    public void Count(string plateColor)
    {
        if (plateColor == "Red") red++;
        if (plateColor == "Blue") blue++;
    }

    public void StartGame()
    {
        //기존 과일 삭제
        foreach (GameObject gameFruit in gameFruits)
        {
            Destroy(gameFruit);
            print("과일 삭제");
        }

        GameObject[] fruits = fruitGenerator.fruits;
        int index1 = Random.Range(0, fruits.Length);
        int index2 = Random.Range(0, fruits.Length);

        if (index1 == index2)
            index2 = Random.Range(0, fruits.Length);

        else if (index1 != index2)
        {
            seeSaw.PlateSetting(fruits[index1].gameObject.tag, fruits[index2].gameObject.tag);
            Debug.Log("Blue: " + fruits[index1].gameObject.tag + ", Red: " + fruits[index2].gameObject.tag);
            blueFruitImage.sprite = gameFruitImages[index1];
            redFruitImage.sprite = gameFruitImages[index2];

            //과일 생성
            fruitGenerator.InstantiateFruits(fruits[index1], fruits[index2]);
        }

        //점수 리셋
        blue = 0;
        red = 0;

        isStarted = true;
    }

    public int CountFruits(int numOfFruits)
    {
        allFruits = numOfFruits;
        return allFruits;
    }
}
