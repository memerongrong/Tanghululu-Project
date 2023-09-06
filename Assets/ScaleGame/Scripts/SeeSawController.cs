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

    //빨간 접시에 올라온 과일과 미션 과일의 이름을 비교하여, 시소를 오른쪽으로 기울이는 메서드
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

    //파란 접시에 올라온 과일과 미션 과일의 이름을 비교하여, 시소를 왼쪽으로 기울이는 메서드
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
