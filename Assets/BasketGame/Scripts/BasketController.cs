using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    BasketGameDirector gameDirector;

    private void Start()
    {
        gameDirector = GameObject.Find("BasketGameDirector").GetComponent<BasketGameDirector>();
    }


    private void Update()
    {
        //마우스 왼쪽 버튼 클릭 시 MoveOnClick 메서드 실행
        if (Input.GetMouseButtonDown(0))
        {
            MoveOnClick();
        }
    }

    //클릭한 위치의 범위가 플레이트 위일 때, 플레이어를 해당 위치로 이동시키는 메서드
    void MoveOnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float x = Mathf.RoundToInt(hit.point.x);
            float z = Mathf.RoundToInt(hit.point.z);
            if (-1 <= x && x <= 1 && -1 <= z && z <= 1)
            {
                transform.position = new Vector3(x, 0, z);
            }
            Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);
        }
    }

    //과일이 바구니에 닿으면 GameDirector에 정보를 전송하고, 과일은 사라지게 하는 메서드
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            gameDirector.GetFruit("Apple");
        }
        else if (other.gameObject.CompareTag("Cherries"))
        {
            gameDirector.GetFruit("Cherries");
        }
        else if (other.gameObject.CompareTag("Lemon"))
        {
            gameDirector.GetFruit("Lemon");
        }
        else if (other.gameObject.CompareTag("Strawberry"))
        {
            gameDirector.GetFruit("Strawberry");
        }
        else if (other.gameObject.CompareTag("Watermelon"))
        {
            gameDirector.GetFruit("Watermelon");
        }
        else
            gameDirector.GetFruit("error!!!");

        Destroy(other.gameObject);
        print(other.gameObject.name + "is destroyed");
    }
}
