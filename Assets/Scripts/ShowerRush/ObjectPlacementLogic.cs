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
    private void CalculateObstaclesAllowed()
    {
        if (PlayersProgress.difficulty <= 4)
        {
            totalAllowedDifficulty = 0;
        }
        else if (PlayersProgress.difficulty > 4 && PlayersProgress.difficulty < 11)
        {
            totalAllowedDifficulty = 1;
        }
        else if (PlayersProgress.difficulty >= 11 && PlayersProgress.difficulty < 17) 
        {
            totalAllowedDifficulty = 2;
        }
        else
        {
            totalAllowedDifficulty = 3;
        }
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
