using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectorManger : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject PipesWithWater;
    public GameObject Shower;
    public GameObject ShowerNoWater;
    public GameObject [] Pipes;
    public GameManagementV2 localManager;
    int correctPipes = 0;

    int totalPipes = 0;

    private void Start()
    {
         localManager = FindObjectOfType<GameManagementV2>();
         totalPipes = PipesHolder.transform.childCount;

         Pipes = new GameObject[totalPipes];

         for (int i = 0; i < Pipes.Length; i++)
         {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
         }
    }

    public void CorrectMove()
    {
        correctPipes += 1;
        Debug.Log(correctPipes);

        if (correctPipes == totalPipes)
        {
            PipesWithWater.SetActive(true);
            PipesHolder.SetActive(false);
            Shower.SetActive(true);
            ShowerNoWater.SetActive(false);
            localManager.WinGame();
        }
    }

    public void WrongMove()
    {
        correctPipes -= 1;
        Debug.Log(correctPipes);
    }
}
