using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class SkewerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float xBound = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SekwelControll();
    }

    void SekwelControll()
    {
        float xPosition = this.transform.position.x;
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }    
}
