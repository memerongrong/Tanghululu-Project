using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
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

    public void AppearTitle()
    {
        if (time < appearingTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, time / appearingTime);
        }

        time += Time.deltaTime;
    }

    public void DisappearTitle()
    {
        print(gameObject.name + "Disappearing . . .");
        if (time < disappearingTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1 - time/disappearingTime);
            time += Time.deltaTime;
        }

        if (time >= disappearingTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTime()
    {
        this.time = 0;
    }
}
