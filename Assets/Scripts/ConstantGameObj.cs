using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstantGameObj : MonoBehaviour
{
    public string objectName = "none";
    void Start()
    {
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        gameObject.SetActive(false);
    }

    public bool CheckTheName(string otherName)
    {
        if (objectName == otherName)
        {
            return true;
        }
        return false;
    }

    public void GameLost()
    {
        SceneManager.LoadScene("menu");
        this.gameObject.SetActive(false);
    }
}
