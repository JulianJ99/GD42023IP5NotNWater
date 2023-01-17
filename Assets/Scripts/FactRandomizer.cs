using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FactRandomizer : MonoBehaviour
{
    [SerializeField]
    List<string> facts = new List<string>();
    static List<string> constantFacts = new List<string>();
    List<string> remainingFacts = new List<string>();
    string fact;
    int index;
    int currentScene = -1;

    void Start()
    {
        constantFacts = facts;
        remainingFacts = constantFacts;
    }



    public string GetFact()
    {
        index = Random.Range(0, remainingFacts.Count);
        fact = remainingFacts[index];

        return fact;
    }
}
