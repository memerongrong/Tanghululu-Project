using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawController : MonoBehaviour
{
    GameObject board;
    GameObject redPlate;
    GameObject bluePlate;
    ScaleGameDirector gameDirector;

    string redFruit;
    string blueFruit;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board");
        redPlate = GameObject.Find("RedPlate");
        bluePlate = GameObject.Find("BluePlate");
        gameDirector = GameObject.Find("GameDirector").GetComponent<ScaleGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlateSetting(string fruit1, string fruit2)
    {
        blueFruit = fruit1;
        redFruit = fruit2;
    }

    //�Ķ� ���ÿ� �ö�� ���ϰ� �̼� ������ �̸��� ���Ͽ�, �üҸ� �������� ����̰�,
    //GameDirector�� ������ �����ϴ� �޼���
    public void BluePlate(string fruitName, ScaleFruitController fruitController, GameObject fruit)
    {
        float boardRotationZ = board.transform.rotation.z;
        if (fruitName == blueFruit)
        {
            float newZ = boardRotationZ += 1.5f;
            transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
            gameDirector.Count("Blue");
            fruit.transform.parent = bluePlate.transform;
            fruit.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //���� ���ÿ� �ö�� ���ϰ� �̼� ������ �̸��� ���Ͽ�, �üҸ� ���������� ����̰�,
    //GameDirector�� ������ �����ϴ� �޼���
    public void RedPlate(string fruitName, ScaleFruitController fruitController, GameObject fruit)
    {
        Quaternion boardRotation = board.transform.rotation;
        if (fruitName == redFruit)
        {
            float newZ = boardRotation.z -= 1.5f;
            transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
            gameDirector.Count("Red");
            fruit.transform.parent = redPlate.transform;
            fruit.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
