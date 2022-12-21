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
    [SerializeField] TextMeshProUGUI livesLost;
    [SerializeField] TextMeshProUGUI livesLeft;
    [SerializeField] TextMeshProUGUI minigameDescription;
    GameObject winScreen;
    GameObject partialLose;
    GameObject loseScreen;
    GameObject gamesUI;
    GameObject pauseMenu;
    GameObject prepUI;
    List<int> scenesWithMinigames = new List<int>()
    {
       1, 2, 3
    };
    public float livesAtTheBeginning;
    private bool actionPerformed = false;

    public bool alive;



    private void Awake()
    {
        Microphone.Start(Microphone.devices[0], false, 1, 1);
        Microphone.End(Microphone.devices[0]);
        DontDestroyOnLoad(this);
    }

    public void Start()
    {

        PlayersProgress.lives = livesAtTheBeginning;
        winScreen = InitializeGameObject("win_screen");
        loseScreen = InitializeGameObject("lose_screen");
        prepUI = InitializeGameObject("preparation");
        pauseMenu = InitializeGameObject("pause_menu");
        gamesUI = InitializeGameObject("ui");
        partialLose = InitializeGameObject("partial_lose");
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
                
                loseScreen.SetActive(false);
                gamesUI.SetActive(false);
                prepUI.SetActive(false);
                partialLose.SetActive(false);
                pointsWon.text = "+" + currentManagingClass.scoreForTheGame + " points";
                funFactText.text = GenerateTheFunFact();
                    winScreen.SetActive(true);
                Time.timeScale = 0;
                }
                else if (currentManagingClass.gameStatus == GameStatus.Paused)
                {
                      PauseTheGame();
                }
                else if (currentManagingClass.gameStatus == GameStatus.Lost)
                {
                Time.timeScale = 0;
                gamesUI.SetActive(false);
                    if (PlayersProgress.lives > 0)
                    {
                    livesLost.text = "You have lost " + currentManagingClass.minigameParameters.hpToLose + " lives";
                    livesLeft.text = "Be careful, only " + PlayersProgress.lives + " lives left";
                    partialLose.SetActive(true);
                        Debug.Log("Game was lost!");
                    }
                    else
                    {
                        lives.text = PlayersProgress.lives + " lives left";
                        loseScreen.SetActive(true);
                        Debug.Log("There's still hope");
                    }
                    //check if theres enough lives and move to another scene if so
                }
                else if (currentManagingClass.gameStatus == GameStatus.Ongoing)
                {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    prepUI.SetActive(false); 
                }
                ManageTheUI();
                }
                else if (currentManagingClass.gameStatus == GameStatus.Not_Started)
            {
                minigameName.text = currentManagingClass.minigameParameters.minigameName;
                minigameDescription.text = currentManagingClass.minigameParameters.minigameDescription;
                prepUI.SetActive(true);

            }
        }
        else
        {
            Debug.Log("Error! Current Game Manager cannot be found. Please restart the game");
        }
    }

    public void PauseTheGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public string GenerateTheFunFact()
    {
        //to be created;
        return "Did you know that saving the planet is humanity's most important mission?";
    }

    public void ManageTheUI()
    {
        if (!gamesUI.activeSelf)
        {
            gamesUI.SetActive(true);
        }
        if (prepUI.activeSelf)
        {
            prepUI.SetActive(false);
        }
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        if (partialLose.activeSelf)
        {
            partialLose.SetActive(false);
        }
        if (loseScreen.activeSelf)
        {
            loseScreen.SetActive(false);
        }
        if (winScreen.activeSelf)
        {
            winScreen.SetActive(false);
        }
    }
    public GameObject InitializeGameObject(string gameObjectName)
    {
        foreach (ConstantGameObj gameObject in Resources.FindObjectsOfTypeAll(typeof(ConstantGameObj)))
            {
            if (gameObject.CheckTheName(gameObjectName))
            {
                return gameObject.gameObject;
            }
        }
        Debug.Log("Object " + gameObjectName + " was not found!");
        return null;
    }

    public bool MoveToTheNextGame()
    {
        List<int> gamesToPickFrom = new List<int>();
        PlayersProgress.difficulty += 1;
        PlayersProgress.minigameNr++;
        foreach(int item in scenesWithMinigames)
        {
            if (PlayersProgress.WasTheGameAlreadyPlayed(item))
            {
                gamesToPickFrom.Add(item);
            }
        }
        if (gamesToPickFrom.Count <= 0)
        {
            gamesToPickFrom = PlayersProgress.listOfPlayedMinigames;
            PlayersProgress.listOfPlayedMinigames = new List<int>();
        }
        int nextGameToLoad = gamesToPickFrom[UnityEngine.Random.Range(0, gamesToPickFrom.Count)];
        minigameNr.text = "Minigame " + PlayersProgress.minigameNr;
        score.text = PlayersProgress.totalScore + " points"; 
        SceneManager.LoadScene(nextGameToLoad);
        return true;
    }
}
