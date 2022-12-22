using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManagementV2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI minigameNr;
    [SerializeField] TextMeshProUGUI pointsWon;
    [SerializeField] TextMeshProUGUI funFactText;
    [SerializeField] TextMeshProUGUI minigameName;
    [SerializeField] TextMeshProUGUI minigameDescription;
    List<int> scenesWithMinigames = new List<int>()
    {
       1, 2, 3, 4
    };
    public float livesAtTheBeginning;
    private bool funFactGenerated = false;

    public bool alive;



    private void Awake()
    {
        DontDestroyOnLoad(this);
        Microphone.Start(Microphone.devices[0], false, 1, 1);
        Microphone.End(Microphone.devices[0]);
    }

    public void Start()
    {
        PlayersProgress.lives = livesAtTheBeginning;
        lives.text = "Lives: " + PlayersProgress.lives;
        minigameNr.text = "Minigame " + PlayersProgress.minigameNr;
        score.text = 0 + " points";
    }
    public void Update()
    {
        GameManagementV2 currentManagingClass = FindObjectOfType<GameManagementV2>();
        if (currentManagingClass != null)
        {
                if (currentManagingClass.gameStatus == GameStatus.Won)
                {

                ActivatePartOfTheUI("win_screen");
                pointsWon.text = "+" + currentManagingClass.scoreForTheGame + " points";
                if (!funFactGenerated)
                {
                    funFactText.text = GenerateTheFunFact();
                }
                Time.timeScale = 0;
                }
                else if (currentManagingClass.gameStatus == GameStatus.Paused)
                {
                      PauseTheGame();
                }
                else if (currentManagingClass.gameStatus == GameStatus.Lost)
                {
               
                    if (PlayersProgress.lives > 0)
                    {
                    ActivatePartOfTheUI("partial_lose");
                        Debug.Log("Game was lost!");
                    }
                    else
                    {
                    Time.timeScale = 0;
                    ActivatePartOfTheUI("lose_screen");
                    }
                    //check if theres enough lives and move to another scene if so
                }
                else if (currentManagingClass.gameStatus == GameStatus.Ongoing)
                {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                ActivatePartOfTheUI("ui");
                }
                else if (currentManagingClass.gameStatus == GameStatus.Not_Started)
            {
                funFactGenerated = false;
                minigameName.text = currentManagingClass.minigameParameters.minigameName;
                minigameDescription.text = currentManagingClass.minigameParameters.minigameDescription;
                ActivatePartOfTheUI("preparation");

            }
        }
        else
        {
          //Debug.Log("Error! Current Game Manager cannot be found. Please restart the game");
        }
    }

    public void PauseTheGame()
    {
        ActivatePartOfTheUI("pause");
        Time.timeScale = 0;
    }
    public string GenerateTheFunFact()
    {
        funFactGenerated = true;
        FactRandomizer factsManagement = GetComponent<FactRandomizer>();
        if (factsManagement != null)
        {
            return factsManagement.GetFact();
        }
        return "Did you know that the fact manager is not working right now?";
    }

    private void ActivatePartOfTheUI(string keyphrase)
    {
        foreach (ConstantGameObj gameObject in Resources.FindObjectsOfTypeAll(typeof(ConstantGameObj)))
        {
            if (gameObject.CheckTheName(keyphrase))
            {
                gameObject.gameObject.SetActive(true);
            }
            else
            {
                gameObject.gameObject.SetActive(false);
            }
        }
    }

    private void UpdateTextboxes(GameStatus gameStatus)
    {
    }

    public bool MoveToTheNextGame()
    {
        List<int> gamesToPickFrom = new List<int>();
        PlayersProgress.difficulty += 1;
        PlayersProgress.minigameNr++;
        foreach (int item in scenesWithMinigames)
        {
            if (PlayersProgress.WasTheGameAlreadyPlayed(item))
            {
                gamesToPickFrom.Add(item);
            }
        }
        if (gamesToPickFrom.Count <= 0)
        {
            PlayersProgress.listOfPlayedMinigames.Remove(SceneManager.GetActiveScene().buildIndex);
            gamesToPickFrom = PlayersProgress.listOfPlayedMinigames;
            PlayersProgress.listOfPlayedMinigames = new List<int>();
        }
        int nextGameToLoad = gamesToPickFrom[UnityEngine.Random.Range(0, gamesToPickFrom.Count)];
        PlayersProgress.listOfPlayedMinigames.Add(nextGameToLoad);
        minigameNr.text = "Minigame " + PlayersProgress.minigameNr;
        score.text = PlayersProgress.totalScore + " points"; 
        SceneManager.LoadScene(nextGameToLoad);
        return true;
    }
}
