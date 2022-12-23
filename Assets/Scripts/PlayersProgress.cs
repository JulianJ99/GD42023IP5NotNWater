using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayersProgress {
    public static int totalScore = 200;
    public static int difficulty = 0;
    public static float lives = 10;
    public static List<int> listOfPlayedMinigames = new List<int>();
    public static int minigameNr = 0;

    public static bool WasTheGameAlreadyPlayed(int nextGameToPlay)
    {
        foreach (int item in listOfPlayedMinigames)
        {
            if (item == nextGameToPlay)
            {
                return false;
            }
        }
        return true;
    }
}
