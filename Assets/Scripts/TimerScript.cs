using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider slider;

    public float timer = 0;
    public float maxTime = -1;

     GameObject Background;
    GameManagementV2 gameManagement;

    void Start()
    {
        /*  float backgroundScaler = GetComponent<RectTransform>().rect.width / Background.GetComponent<RectTransform>().rect.width;

        slider.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, slider.GetComponent<RectTransform>().rect.height);
        Background.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, Background.GetComponent<RectTransform>().rect.height * backgroundScaler);

        */
    }
    public void InitializeTheTimer()
    {
        gameManagement = GetComponent<GameManagementV2>();
        if (gameManagement != null)
        {
            maxTime = gameManagement.calculatedTimeForLvl / 1000;
        }
    }
    void Update()
    {
        slider = FindObjectOfType<Slider>();
        if (slider != null && maxTime != -1 && gameManagement.gameStatus == GameStatus.Ongoing)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        slider.GetComponent<Slider>().value = slider.GetComponent<Slider>().value - (Time.deltaTime / maxTime);
    }

    public float GetCurrentTime()
    {
        return timer;
    }
}
