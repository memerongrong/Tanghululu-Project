using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isStarted = false;
    bool isSelected = false;

    TitleScript title;
    TitleScript selectTitle;
    ButtonAnimationController startButton;
    ButtonAnimationController startButtonImage;
    ButtonAnimationController basketButton;
    ButtonAnimationController scaleButton;
    ButtonAnimationController skewerButton;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title").GetComponent<TitleScript>();
        selectTitle = GameObject.Find("Select Game").GetComponent<TitleScript>();

        startButton = GameObject.Find("Start Button Image").GetComponent<ButtonAnimationController>();
        startButtonImage = GameObject.Find("Start Button Image").GetComponent<ButtonAnimationController>();
        basketButton = GameObject.Find("Basket Button").GetComponent<ButtonAnimationController>();
        scaleButton = GameObject.Find("Scale Button").GetComponent<ButtonAnimationController>();
        skewerButton = GameObject.Find("Skewer Button").GetComponent<ButtonAnimationController>();

    }

    // Update is called once per frame
    void Update()
    {
        //게임 실행했을 때, 타이틀 띄우기
        if (!isStarted)
        {
            title.AppearTitle();
            startButton.AppearStartButton();
        }

        //GameStart 메서드 호출('Start' 버튼 클릭) 시 실행되는 코드
        if (isStarted && !isSelected)
        {
            title.DisappearTitle();
            startButton.DisappearButton();
            startButtonImage.DisappearButton();

            selectTitle.AppearTitle();
            basketButton.AppearButton();
            scaleButton.AppearButton();
            skewerButton.AppearButton();
        }

        //게임 하나가 선택되면 실행되는 코드
        if (isSelected)
        {

        }
    }
    
    //Start 버튼에 연결된 메서드
    public void GameStart()
    {
        print("Game Start ! ! !");
        isStarted = true;
        title.ResetTime();
        startButton.ResetTime();
        basketButton.ResetTime();
        scaleButton.ResetTime();
        skewerButton.ResetTime();
    }

    void BasketGameStart()
    {

    }

    void ScaleGameStart()
    {

    }

    void SkewerGameStart()
    {

    }
}
