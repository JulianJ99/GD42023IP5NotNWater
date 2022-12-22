using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopMain : MonoBehaviour
{
    public Text money;
    void Start()
    {
        money.text = PlayersProgress.totalScore.ToString();
    }

    void Update()
    {
        money.text = PlayersProgress.totalScore.ToString();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
