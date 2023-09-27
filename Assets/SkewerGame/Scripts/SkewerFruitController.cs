using UnityEngine;

public class SkewerFruitController : MonoBehaviour
{
    bool isFalling;
    bool isSkewered;

    SkewerController skewerController;

    void Start()
    {
        //게임이 로드 될 때 isFalling 변수를 true로 설정
        isFalling = true;
        skewerController = GameObject.Find("Skewer").GetComponent<SkewerController>();
    }

    void Update()
    {
        //isFalling 변수가 true인 동안 과일을 아래로 낙하시킴
        if (isFalling)
            transform.Translate(0, 0, -0.1f);

        float heightLimit = -1.5f;
        if (this.transform.position.y < heightLimit)
            Destroy(gameObject);
    }

    //Trigger 감지되면 tag를 비교하여 꼬치인지 확인하고, 꼬치라면 과일을 꼬치의 자식으로 등록
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skewer"))
        {
            this.transform.parent = other.transform;
        }
    }

    //Collision이 감지되면 과일 낙하를 멈춰 꼬치에 끼워진 것처럼 보이도록 구현
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.CompareTag("Skewer") && !isSkewered)
        {
            isSkewered = true;
            isFalling = false;
            print("Skewer got " + this.tag);
            skewerController.CountFruits(this.tag, this.gameObject); 
        }
        else 
            print(this.tag + " collision with: " + collision.gameObject.tag + ", It's parent is: " + collision.gameObject.transform.parent.tag);
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
        print(gameObject.tag + " is destroyed.");
    }
}
