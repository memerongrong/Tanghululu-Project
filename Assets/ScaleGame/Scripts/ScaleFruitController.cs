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

    //과일에 Collision이 감지되면, 접촉한 물체의 tag를 확인한 후 시소의 접시를 호출하는 메서드
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
