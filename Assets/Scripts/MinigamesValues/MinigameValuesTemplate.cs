using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MinigameValuesTemplate : ScriptableObject
{
    public float timeToCompleteLevel;
    public int basePointsForLevel;
    public int bonusPointsMax;
    public string minigameName;
    public float minimumTimeThreshold;
    public GameScenarios gameScenarios = GameScenarios.Rush;
    public Color interfaceColor;
    public AudioClip musicForTheMinigame;
    public string minigameDescription;
    public int waterAmountToLose;
}
