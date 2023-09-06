using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasketFruitDropper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //동적으로 Rigidbody컴퍼넌트를 생성
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 떨어지는 속도(dropSpeed)를 설정하고, 업데이트마다 떨어지도록 설정
        float dropSpeed = 0.05f;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - dropSpeed, this.transform.position.z);

        //y축 값이 일정 높이(limitLine) 미만이 되면 삭제되도록 설정
        float limitLine = -20.0f;
        if (this.transform.position.y < limitLine)
        {
            Destroy(gameObject);
        }
    }
}
