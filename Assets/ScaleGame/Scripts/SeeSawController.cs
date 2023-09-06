using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawController : MonoBehaviour
{
    GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���� ���ÿ� �ö�� ���ϰ� �̼� ������ �̸��� ���Ͽ�, �üҸ� ���������� ����̴� �޼���
    public void RedPlate(string fruitName, ScaleFruitController fruitController)
    {
        Quaternion boardRotation = board.transform.rotation;
        if (fruitName == "Cherries")
        {
            float newZ = boardRotation.z -= 1.5f;
            transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
        }
    }

    //�Ķ� ���ÿ� �ö�� ���ϰ� �̼� ������ �̸��� ���Ͽ�, �üҸ� �������� ����̴� �޼���
    public void BluePlate(string fruitName, ScaleFruitController fruitController)
    {
        float boardRotationZ = board.transform.rotation.z;
        if (fruitName == "Cherries")
        {
            float newZ = boardRotationZ += 1.5f;
            transform.Rotate(0, 0, newZ);
            fruitController.Scaled();
        }
    }
}
