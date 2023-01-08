using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectorManger : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject [] Pipes;
    int correctPipes = 0;

    int totalPipes = 0;

    private void Start()
    {
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

        if (correctPipes == totalPipes)
        {
            Debug.Log("YOU WON");
        }
    }

    public void WrongMove()
    {
        correctPipes -= 1;
    }
}
