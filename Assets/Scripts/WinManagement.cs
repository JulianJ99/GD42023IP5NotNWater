using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinManagement : MonoBehaviour
{
    public TextMeshProUGUI textToRotate;
    public TextMeshProUGUI mainPointsText;
    public TextMeshProUGUI bonusText;
    public AudioClip bonusPointsSound;
    int mainPoints = 0;
    int actualPts = 0;
    int bonusPoints = 0;
    int preAddedPoints=  0;
    bool hasStartedAnimation = false;
    float maximumTimeForAnimation = 1.15f;
    List<string> randomEncouragingTexts = new List<string>()
    {
        "Good job!", "Perfect!", "Excellent!", "Brilliant!", "Oh yeah", "Let's Gooo", "Nice!", "Super!", "Keep going!"
    };
    public AudioClip cheeringSoundToPlay;
    public GameObject bonusUIGroup;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        mainPoints = FindObjectOfType<GameManagementV2>().totalBaseScore;
        bonusPoints = FindObjectOfType<GameManagementV2>().totalBonusScore;
        textToRotate.text = randomEncouragingTexts[UnityEngine.Random.Range(0, randomEncouragingTexts.Count)];
        actualPts = System.Convert.ToInt32(System.Math.Round(mainPoints * 0.4f, 1));
        mainPointsText.text = "+" + actualPts;
        bonusText.text = bonusPoints.ToString();
        bonusUIGroup.SetActive(false);
        source = GetComponent<AudioSource>();
        int rotationAngle = UnityEngine.Random.Range(-4, 5);
        textToRotate.transform.Rotate(new Vector3(0, 0, rotationAngle), Space.World);
        source.PlayOneShot(cheeringSoundToPlay);

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartedAnimation)
        {
            if (actualPts < mainPoints)
            {
                StartCoroutine(AnimationCoroutine(mainPoints, maximumTimeForAnimation));
            }
            else if (actualPts >= mainPoints && actualPts < mainPoints + bonusPoints && bonusPoints > 0)
            {
                if (!bonusUIGroup.activeSelf)
                {
                    bonusUIGroup.SetActive(true);
                }
                StartCoroutine(AnimationCoroutine(bonusPoints, maximumTimeForAnimation * 0.85f));
            }
            else
            {
                StartCoroutine(DestroyObject());
            }
        }
    }

    IEnumerator AnimationCoroutine(int maxPointsPerAnimation, float timeForAnimation)
    {
        hasStartedAnimation = true;
        float finalAmountToWait = timeForAnimation / UnityEngine.Random.Range(maxPointsPerAnimation * 0.875f, maxPointsPerAnimation * 1.15f);
        if (mainPoints - actualPts == 0)
        {
            finalAmountToWait+=0.55f;
        }
        yield return new WaitForSeconds(finalAmountToWait);
        actualPts++;
        mainPointsText.text = "+" + actualPts;
        source.PlayOneShot(bonusPointsSound);
        hasStartedAnimation = false;
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
    IEnumerator OptionalCoroutine()
    {
        yield return new WaitForSeconds(1);

    }
}
