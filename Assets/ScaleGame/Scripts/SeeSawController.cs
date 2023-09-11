using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SeeSawController : MonoBehaviour
{
    GameObject board;
    GameObject redPlate;
    GameObject bluePlate;
    ScaleGameDirector gameDirector;

    string redFruit;
    string blueFruit;

    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board");
        redPlate = GameObject.Find("RedPlate");
        bluePlate = GameObject.Find("BluePlate");
        gameDirector = GameObject.Find("GameDirector").GetComponent<ScaleGameDirector>();

        originalRotation = board.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlateSetting(string fruit1, string fruit2)
    {
        blueFruit = fruit1;
        redFruit = fruit2;
        board.GetComponent<Transform>().rotation = originalRotation;
    }

    //파란 접시에 올라온 과일과 미션 과일의 이름을 비교하여, 시소를 왼쪽으로 기울이고,
    //GameDirector에 점수를 전달하는 메서드
    public void BluePlate(string fruitName, ScaleFruitController fruitController, GameObject fruit)
    {
        float boardRotationZ = board.transform.rotation.z;
        if (fruitName == blueFruit)
        {
            float newZ = boardRotationZ += 1.5f;
            board.transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
            gameDirector.Count("Blue");
            fruit.transform.parent = bluePlate.transform;
            fruit.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //빨간 접시에 올라온 과일과 미션 과일의 이름을 비교하여, 시소를 오른쪽으로 기울이고,
    //GameDirector에 점수를 전달하는 메서드
    public void RedPlate(string fruitName, ScaleFruitController fruitController, GameObject fruit)
    {
        Quaternion boardRotation = board.transform.rotation;
        if (fruitName == redFruit)
        {
            float newZ = boardRotation.z -= 1.5f;
            board.transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
            gameDirector.Count("Red");
            fruit.transform.parent = redPlate.transform;
            fruit.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
