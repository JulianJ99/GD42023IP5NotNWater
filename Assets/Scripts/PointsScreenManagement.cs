using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsScreenManagement : MonoBehaviour
{
    public TextMeshProUGUI mainPointsText;
    public TextMeshProUGUI countDownText;
    public AudioClip bonusPointsSound;
    bool countdownStarted = false;
    int totalPoints = 0;
    public int pointsToAdd = 20;
    int alreadyAddedPoints = 0;
    bool hasStartedAnimation = false;
    int timeUntilNextLevel = 5;
    float maximumTimeForAnimation = 1;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        totalPoints = PlayersProgress.totalScore - pointsToAdd;
        alreadyAddedPoints = 0;
        timeUntilNextLevel = 5;
        mainPointsText.text = totalPoints.ToString();
        countdownStarted = false;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartedAnimation)
        {
            if (alreadyAddedPoints < pointsToAdd)
            {
                StartCoroutine(AnimationCoroutine(pointsToAdd, maximumTimeForAnimation));
            }
        }
        if (!countdownStarted && timeUntilNextLevel > 0)
        {
            StartCoroutine(CountdownCoroutine());
        }
        else if (timeUntilNextLevel <= 0)
        {
            countDownText.text = "(5)";
            GetComponent<ButtonHandlerScript>().PlayNextGame();
        }
    }

    IEnumerator AnimationCoroutine(int maxPointsPerAnimation, float timeForAnimation)
    {
        hasStartedAnimation = true;
        float finalAmountToWait = timeForAnimation / UnityEngine.Random.Range(maxPointsPerAnimation * 0.9f, maxPointsPerAnimation * 1.05f);
        if (alreadyAddedPoints == 0)
        {
            finalAmountToWait += 0.4f;
        }
        yield return new WaitForSeconds(finalAmountToWait);
        alreadyAddedPoints++;
        mainPointsText.text = System.Convert.ToString(totalPoints + alreadyAddedPoints);
        source.PlayOneShot(bonusPointsSound);
        hasStartedAnimation = false;
    }
    IEnumerator CountdownCoroutine()
    {
        countdownStarted = true;
        yield return new WaitForSeconds(1.03f);
        timeUntilNextLevel--;
        countDownText.text = "(" + timeUntilNextLevel + ")";
        countdownStarted = false;
    }

}
