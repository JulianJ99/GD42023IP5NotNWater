using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactRandomizer : MonoBehaviour
{
    [SerializeField]
    List<string> constantFacts = new List<string>();
    List<string> remainingFacts = new List<string>();
    string fact;
    int index;

    void Start()
    {
        remainingFacts = constantFacts;
    }


    public string GetFact()
    {
        index = Random.Range(0, remainingFacts.Count);
        fact = remainingFacts[index];
        remainingFacts.RemoveAt(index);

        if (remainingFacts.Count == 0)
            remainingFacts = constantFacts;

        return fact;
    }
}
