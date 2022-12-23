using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartialLossManagement : MonoBehaviour
{
    public TextMeshProUGUI proceedToTheNextLevel;
    public TextMeshProUGUI livesLeftText;
    public TextMeshProUGUI lossIndicator;
    public Image imageToChange;
    public List<Sprite> visualHealthVariations;
    int timeUntilNextLevel = 4;
    int hpLostByPlayer = 1;
    int hpLossShown = 0;
    float livesLeft = 0;
    bool countdownStarted = false;
    bool delayWasPassed = false;
    bool lossIndicatorIsSeen = false;
    float timeToDisplayHitIndicator = 0.45f;
    public Vector2 centerOfTheBar;
    public AudioClip hpLossSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        hpLostByPlayer = FindObjectOfType<GameManagementV2>().minigameParameters.waterAmountToLose;
        timeUntilNextLevel = 4;
        delayWasPassed = false;
        livesLeft = PlayersProgress.lives + hpLostByPlayer;
        livesLeftText.text = livesLeft.ToString();
        StartCoroutine(OptionalDelay());
        lossIndicatorIsSeen = false;
        hpLossShown = 0;
        countdownStarted = false;
    }

    private void OnDisable()
    {
        lossIndicator.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (!countdownStarted && timeUntilNextLevel > 0)
        {
            StartCoroutine(CountdownCoroutine());
        }
        else if (timeUntilNextLevel <= 0)
        {
            proceedToTheNextLevel.text = "(4)";
            GetComponent<ButtonHandlerScript>().PlayNextGame();
        }
        DisplayWaterLoss();
    }

    private void DisplayWaterLoss()
    {
        if (hpLossShown < hpLostByPlayer && delayWasPassed)
        {
            if (!lossIndicatorIsSeen)
            {
                Vector3 indicatorPos = lossIndicator.transform.position;
               lossIndicator.transform.position.Set(UnityEngine.Random.Range(indicatorPos.x - 5, indicatorPos.x + 5), 
                    UnityEngine.Random.Range(indicatorPos.y - 10, indicatorPos.y + 11), indicatorPos.z);
                livesLeft--;
                imageToChange.sprite = visualHealthVariations[Convert.ToInt32(livesLeft) - 1];
                livesLeftText.text = livesLeft.ToString();
                StartCoroutine(DisplayLossCoroutine());
                GetComponent<AudioSource>().PlayOneShot(hpLossSound);
         
            }
            else if (lossIndicatorIsSeen)
            {
                lossIndicator.transform.position.Set(lossIndicator.transform.position.x + 5,
                    lossIndicator.transform.position.y, lossIndicator.transform.position.z);
            }
        }
            
    }
    IEnumerator CountdownCoroutine()
    {
        countdownStarted = true;
        yield return new WaitForSeconds(1.06f);
        timeUntilNextLevel--;
        proceedToTheNextLevel.text = "(" + timeUntilNextLevel + ")";
        countdownStarted = false;
    }

    IEnumerator DisplayLossCoroutine()
    {
        lossIndicator.text = "-1";
        lossIndicatorIsSeen = true;
        yield return new WaitForSeconds(timeToDisplayHitIndicator);
        lossIndicator.text = "";
        hpLossShown++;
        yield return new WaitForSeconds(timeToDisplayHitIndicator / 1.7f);
        lossIndicatorIsSeen = false;
        //lossIndicator.transform.position = centerOfTheBar;

    }

    IEnumerator OptionalDelay()
    {
        yield return new WaitForSeconds(0.3f);
        delayWasPassed = true;
    }
}
