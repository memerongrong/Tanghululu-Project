using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerFruitGenerator : MonoBehaviour
{
    float span = 1.0f;
    float delta = 0.0f;
    public GameObject[] fruits;
    Vector3[] spawners = new Vector3[3];

    // Start is called before the first frame update
    void Start()
    {
        spawners[0] = new Vector3(-3.5f, 8.0f, -8.5f);
        spawners[1] = new Vector3(0.0f, 8.0f, -8.5f);
        spawners[2] = new Vector3(3.5f, 8.0f, -8.5f);
    }

    // Update is called once per frame
    void Update()
    {
        delta = delta + Time.deltaTime;

        if (delta >= span)
        {
            delta = 0.0f;
            print("Generating fruit . . .");
        }
    }
}
