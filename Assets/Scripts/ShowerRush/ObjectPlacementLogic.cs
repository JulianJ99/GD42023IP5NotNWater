using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementLogic : MonoBehaviour
{
    public GameObject bathroomGoalPrefab;
    public Transform playerInitialPosition;
    private int totalAllowedDifficulty = 0;
    private int maximumDifficultyThreshold = 10;
    private int distanceBetweenObstacles = 6;
    public List<ObstacleToPlace> allObstacles;
    float timeLeft = 0;
    float calculatedTimeForLvl = 1000;
    public List<GameObject> puddlesToDisplay;

    [System.Serializable]
    public class ObstacleToPlace
    {
        public int difficultyLevel;
        public GameObject obstaclePrefab;
        public string actionRequired;
        public float distanceBeforeObstacle;
    }
    void Start()
    {
        CalculateObstaclesAllowed();
        InitializeObstacles();
    }
    private void Update()
    {
        PuddlesManagementScript();
    }
    private void CalculateObstaclesAllowed()
    {
        totalAllowedDifficulty = PlayersProgress.difficulty;
    }
    private void PuddlesManagementScript()
    {
        int currentStatus = 0;
        GameManagementV2 localGameManagement = FindObjectOfType<GameManagementV2>();
        if (localGameManagement != null)
        {
            timeLeft = localGameManagement.levelTimer.ElapsedMilliseconds;
            calculatedTimeForLvl = localGameManagement.calculatedTimeForLvl;
        }
        float percentageLeft = timeLeft / calculatedTimeForLvl;
        if (percentageLeft > 0.4f && percentageLeft < 0.56f)
        {
            currentStatus = 1;
        }
        else if (percentageLeft > 0.56f && percentageLeft < 0.72f)
        {
            currentStatus = 2;
        }
        else if (percentageLeft > 0.72f && percentageLeft < 0.86f)
        {
            currentStatus = 3;
        }
        else if (percentageLeft > 0.86f)
        {
            currentStatus = 4;
        }
        puddlesToDisplay[currentStatus - 1].SetActive(true);
    }
    private void InitializeObstacles()
    {
        int totalDifficultyObjects = 0;
        float totalLengthOfTrack = playerInitialPosition.position.x - 1;
        for (int i = 0; i < 4; i++)
        {
            if (totalDifficultyObjects < totalAllowedDifficulty)
            {
                int itemToPick = UnityEngine.Random.Range(0, allObstacles.Count);
                if (totalDifficultyObjects + allObstacles[itemToPick].difficultyLevel > 3)
                {
                    i -= 1;
                }
                else
                {
                    ObstacleToPlace obstacle = allObstacles[itemToPick];
                    float coordinateY = 0;
                    if (obstacle.actionRequired == "jump")
                    {
                        coordinateY = -1.95f;
                    }
                    else if (obstacle.actionRequired == "crouch")
                    {
                        coordinateY = 1.3f;
                    }

                    totalLengthOfTrack += allObstacles[itemToPick].distanceBeforeObstacle + obstacle.obstaclePrefab.GetComponent<Collider2D>().bounds.size.x;
                    Vector2 spawnPosition = new Vector2(totalLengthOfTrack, coordinateY);
                    Instantiate(allObstacles[itemToPick].obstaclePrefab, spawnPosition, Quaternion.identity);
                    totalDifficultyObjects += allObstacles[itemToPick].difficultyLevel;
                    allObstacles.Remove(allObstacles[itemToPick]);              
                }
            }
        }
    }
}
