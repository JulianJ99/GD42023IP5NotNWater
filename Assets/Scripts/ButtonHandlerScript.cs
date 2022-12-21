using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerScript : MonoBehaviour
{
    private void Start()
    {
    }
    private void Awake()
    {
    }
    public void StartGame()
    {
        GameManagementV2 gameManagement = FindObjectOfType<GameManagementV2>();
        if (gameManagement == null)
        {
            Debug.Log("Not found");
        }
        gameManagement.StartTheGame();
    }

    public void PlayNextGame()
    {
        GlobalGameManagementV2 globalGameManagement = FindObjectOfType<GlobalGameManagementV2>();
        globalGameManagement.MoveToTheNextGame();
        gameObject.SetActive(true);
    }
}
