using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ButtonAnimationController : MonoBehaviour
{
    float time = 0;
    float appearingTime = 1;
    float disappearingTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void AppearStartButton()
    {
        if (time < appearingTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.localScale = new Vector3(0.1f, 0.1f, 0.0f) * (time * 10);
            time += Time.deltaTime;
        }
    }

    public void AppearButton()
    {
        if (time < appearingTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, time / appearingTime);
            print(gameObject.name + ", " + GetComponent<Image>().color);
            time += Time.deltaTime;
        }
    }

    public void DisappearButton()
    {
        if (time < disappearingTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1 - time / disappearingTime);
            time += Time.deltaTime;
        }
    }
    public void ResetTime()
    {
        this.time = 0;
        print(gameObject.name + "'s time reset");
    }
}
