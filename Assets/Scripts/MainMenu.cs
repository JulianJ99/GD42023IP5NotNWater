using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public GameObject GlitchEffect;
    GlobalGameManagementV2 playTheGame;
    public GameObject toSetActive;
    private void Start()
    {
        playTheGame = GetComponent<GlobalGameManagementV2>();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ActivateTest()
    {
        toSetActive.SetActive(true);
    }
    public void PlayGame()
    {
        playTheGame = FindObjectOfType<GlobalGameManagementV2>();
        playTheGame.MoveToTheNextGame();
    }

    public void Tips()
    {
        SceneManager.LoadScene("tips");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

}
