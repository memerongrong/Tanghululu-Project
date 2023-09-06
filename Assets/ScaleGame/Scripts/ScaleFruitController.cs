using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleFruitController : MonoBehaviour
{
    SeeSawController seeSaw;
    ScaleFruitController scaleFruitController;
    public bool isScaled;
    // Start is called before the first frame update
    void Start()
    {
        seeSaw = GameObject.Find("SeeSaw").GetComponent<SeeSawController>();
        scaleFruitController = this.gameObject.GetComponent<ScaleFruitController>();
        isScaled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���Ͽ� Collision�� �����Ǹ�, ������ ��ü�� tag�� Ȯ���� �� �ü��� ���ø� ȣ���ϴ� �޼���
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedPlate"))
        {
            if (!isScaled)
            {
                seeSaw.RedPlate(this.gameObject.tag, scaleFruitController);
            }
        }

        if (collision.gameObject.CompareTag("BluePlate"))
        {
            if (!isScaled)
            {
                seeSaw.BluePlate(this.gameObject.tag, scaleFruitController);
            }
        }
    }

    public void Scaled()
    {
        if (!isScaled)
        isScaled = true;
    }
}
