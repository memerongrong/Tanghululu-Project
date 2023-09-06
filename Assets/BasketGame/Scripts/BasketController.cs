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
        //���콺 ���� ��ư Ŭ�� �� MoveOnClick �޼��� ����
        if (Input.GetMouseButtonDown(0))
        {
            MoveOnClick();
        }
    }

    //Ŭ���� ��ġ�� ������ �÷���Ʈ ���� ��, �÷��̾ �ش� ��ġ�� �̵���Ű�� �޼���
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

    //������ �ٱ��Ͽ� ������ GameDirector�� ������ �����ϰ�, ������ ������� �ϴ� �޼���
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
