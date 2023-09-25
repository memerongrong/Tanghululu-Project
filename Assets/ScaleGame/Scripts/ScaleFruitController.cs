
using System.Security;
using UnityEngine;

public class ScaleFruitController : MonoBehaviour
{
    SeeSawController seeSaw;
    ScaleFruitController scaleFruitController;

    bool isScaled;
    bool isFalling;
    float fallingSpeed;

    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        seeSaw = GameObject.Find("SeeSaw").GetComponent<SeeSawController>();
        scaleFruitController = this.gameObject.GetComponent<ScaleFruitController>();
        isScaled = false;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling) fallingSpeed = 1.0f;
        if (!isFalling) fallingSpeed = 0;

        this.transform.Translate(0, 0, -fallingSpeed);
    }
    

    //���Ͽ� Collision�� �����Ǹ�, ������ ��ü�� tag�� Ȯ���� �� �ü��� ���ø� ȣ���ϴ� �޼���
    private void OnCollisionEnter(Collision collision)
    {
                    isFalling = false;
        if (collision.gameObject.CompareTag("BluePlate"))
        {
            if (!isScaled)
            {
                seeSaw.BluePlate(this.gameObject.tag, scaleFruitController, this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("RedPlate"))
        {
            if (!isScaled)
            {
                seeSaw.RedPlate(this.gameObject.tag, scaleFruitController, this.gameObject);
            }
        }
    }

    //���� ��ٿ�� ���� bool�� ����
    public void Scaled()
    {
        if (!isScaled)
            isScaled = true;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnMouseUp()
    {
        if(!isScaled)
            isFalling = true;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void Restart()
    {
        Destroy(this.gameObject);
    }
}
