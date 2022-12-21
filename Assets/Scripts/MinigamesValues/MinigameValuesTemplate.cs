using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MinigameValuesTemplate : ScriptableObject
{
    public float timeToCompleteLevel;
    public int maximumPoints;
    public string minigameName;
    public float minimumTimeAllowed;
    public AudioClip musicForTheMinigame;
    public string minigameDescription;
    public int hpToLose;
}
