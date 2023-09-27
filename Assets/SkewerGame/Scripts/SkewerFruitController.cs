using UnityEngine;

public class SkewerFruitController : MonoBehaviour
{
    bool isFalling;
    bool isSkewered;

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

        float heightLimit = -1.5f;
        if (this.transform.position.y < heightLimit)
            Destroy(gameObject);
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
