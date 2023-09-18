using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class SkewerFruitController : MonoBehaviour
{
    bool isFalling;

    SkewerController skewerController;

    void Start()
    {
        //������ �ε� �� �� isFalling ������ true�� ����
        isFalling = true;
        skewerController = GameObject.Find("Skewer").GetComponent<SkewerController>();
    }

    void Update()
    {
        //isFalling ������ true�� ���� ������ �Ʒ��� ���Ͻ�Ŵ
        if (isFalling)
            transform.Translate(0, 0, -0.1f);
    }

    //Trigger �����Ǹ� tag�� ���Ͽ� ��ġ���� Ȯ���ϰ�, ��ġ��� ������ ��ġ�� �ڽ����� ���
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skewer"))
        {
            this.transform.parent = other.transform;
        }
    }

    //Collision�� �����Ǹ� ���� ���ϸ� ���� ��ġ�� ������ ��ó�� ���̵��� ����
    private void OnCollisionEnter(Collision collision)
    {
        isFalling = false;
        skewerController.CountFruits(this.tag);
    }
}
