using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagementV2 : MonoBehaviour
{
    public int totalBaseScore = 0;
    public int totalBonusScore = 0;
    public float calculatedTimeForLvl = 1000;
    public Stopwatch levelTimer = new Stopwatch();
    public MinigameValuesTemplate minigameParameters;
    public GameStatus gameStatus = GameStatus.Not_Started;
    private Slider slider;

    private void Start()
    {
        Time.timeScale = 0;
        CalculateTimeForTheLevel();
        GetComponent<TimerScript>().InitializeTheTimer();
        GetComponentInChildren<AudioSource>().clip = minigameParameters.musicForTheMinigame;
        GetComponentInChildren<AudioSource>().Play();
    }

    public void CalculateTimeForTheLevel()
    {
        calculatedTimeForLvl = minigameParameters.timeToCompleteLevel * 1000;
        calculatedTimeForLvl -= calculatedTimeForLvl * PlayersProgress.difficulty * 0.0425f;
        if (calculatedTimeForLvl < minigameParameters.minimumTimeThreshold * 1000)
        {
            calculatedTimeForLvl = minigameParameters.minimumTimeThreshold * 1000;
        }
    }
    private void Update()
    {
        if (levelTimer.ElapsedMilliseconds > calculatedTimeForLvl && gameStatus == GameStatus.Ongoing)
        {
            if (minigameParameters.gameScenarios == GameScenarios.Rush || 
                minigameParameters.gameScenarios == GameScenarios.Calculate)
            {
                LoseGame();
            }
            else if (minigameParameters.gameScenarios == GameScenarios.Hold)
            {
                WinGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //escape for now, change to a sensor-responding button later
        {
            if (gameStatus == GameStatus.Ongoing)
            {
                levelTimer.Stop();
                gameStatus = GameStatus.Paused;
            }
            else if (gameStatus == GameStatus.Paused)
            {
                levelTimer.Start();
                gameStatus = GameStatus.Ongoing;
            }
        }
    }



    public void WinGame()
    {
        float playersReactionPercentage = (calculatedTimeForLvl - levelTimer.ElapsedMilliseconds) / calculatedTimeForLvl;
        if (gameStatus != GameStatus.Won && gameStatus == GameStatus.Ongoing)
        {
            GetComponent<AudioSource>().Stop();
            gameStatus = GameStatus.Won;
            PlayersProgress.listOfPlayedMinigames.Add(SceneManager.GetActiveScene().buildIndex);
            PlayersProgress.totalScore += CalculateScoreToAdd(playersReactionPercentage);
            ResetTheTimer();
        }
        
    }
    public void ResetTheTimer()
    {
        levelTimer.Stop();
        FindObjectOfType<TimerScript>().slider.value = 1;
    }
    public int CalculateScoreToAdd(float playersReductionPercentage)
    {
        float bonusDifficultyMultiplier = 1 + (PlayersProgress.difficulty / 12);
        totalBaseScore = Convert.ToInt32(minigameParameters.basePointsForLevel * bonusDifficultyMultiplier);
        totalBonusScore = Convert.ToInt32((playersReductionPercentage * minigameParameters.bonusPointsMax) * bonusDifficultyMultiplier);
        return totalBaseScore + totalBonusScore;
    }
    public void LoseGame()
    {
        if (gameStatus != GameStatus.Lost && gameStatus == GameStatus.Ongoing)
        {
            GetComponent<AudioSource>().Stop();
            gameStatus = GameStatus.Lost;
            PlayersProgress.listOfPlayedMinigames.Add(SceneManager.GetActiveScene().buildIndex);
            PlayersProgress.lives -= minigameParameters.waterAmountToLose;
            ResetTheTimer();
            PlayersProgress.difficulty -= 1;
        }
    }

    public void StartTheGame()
    {
        levelTimer.Start();
        gameStatus = GameStatus.Ongoing;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
