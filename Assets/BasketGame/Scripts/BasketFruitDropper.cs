using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasketFruitDropper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�������� Rigidbody���۳�Ʈ�� ����
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �������� �ӵ�(dropSpeed)�� �����ϰ�, ������Ʈ���� ���������� ����
        float dropSpeed = 0.05f;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - dropSpeed, this.transform.position.z);

        //y�� ���� ���� ����(limitLine) �̸��� �Ǹ� �����ǵ��� ����
        float limitLine = -20.0f;
        if (this.transform.position.y < limitLine)
        {
            Destroy(gameObject);
        }
    }
}
