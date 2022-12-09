using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagementV2 : MonoBehaviour
{
    public int scoreForTheGame = 0;
    public float calculatedTimeForLvl = 1000;
    public Stopwatch levelTimer = new Stopwatch();
    public MinigameValuesTemplate minigameParameters;
    public GameStatus gameStatus = GameStatus.Not_Started;
    public Slider slider;

    private void Start()
    {
        Time.timeScale = 0;
        CalculateTimeForTheLevel();
        GetComponentInChildren<AudioSource>().clip = minigameParameters.musicForTheMinigame;
        GetComponentInChildren<AudioSource>().Play();
    }

    public void CalculateTimeForTheLevel()
    {
        calculatedTimeForLvl = minigameParameters.timeToCompleteLevel * 1000;
        calculatedTimeForLvl -= calculatedTimeForLvl * PlayersProgress.difficulty * 0.04f;
    }
    private void Update()
    {
        if (levelTimer.ElapsedMilliseconds > calculatedTimeForLvl && gameStatus == GameStatus.Ongoing)
        {
            LoseGame();
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
        float playersReactionPercentage = levelTimer.ElapsedMilliseconds / calculatedTimeForLvl;
        if (gameStatus != GameStatus.Won)
        {
            gameStatus = GameStatus.Won;
            PlayersProgress.listOfPlayedMinigames.Add(SceneManager.GetActiveScene().buildIndex);
            scoreForTheGame = CalculateScoreToAdd(playersReactionPercentage);
            PlayersProgress.totalScore += scoreForTheGame;
        }
        
    }

    public int CalculateScoreToAdd(float playersReductionPercentage)
    {
        float bonusDifficultyMultiplier = 1 + (PlayersProgress.difficulty / 12);
        float result = minigameParameters.maximumPoints * (1 + playersReductionPercentage) * bonusDifficultyMultiplier;
        return Convert.ToInt32(result);
    }
    public void LoseGame()
    {
        if (gameStatus != GameStatus.Lost)
        {
            gameStatus = GameStatus.Lost;
            PlayersProgress.lives -= minigameParameters.hpToLose;
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
