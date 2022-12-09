using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text scoreText;
    public GameObject soldPanelShower1;
    public GameObject soldPanelShower2;
    public GameObject soldPanelShower3;

    public Button buySkin1;
    public Button buySkin2;
    public Button buySkin3;

    private void Start()
    {
        scoreText.text = "10000";
    }

    public void BuyShowerSkin1()
    {
        soldPanelShower1.SetActive(true);
        buySkin1.interactable = false;
    }

    public void BuyShowerSkin2()
    {
        soldPanelShower2.SetActive(true);
        buySkin2.interactable = false;
    }

    public void BuyShowerSkin3()
    {
        soldPanelShower3.SetActive(true);
        buySkin3.interactable = false;
    }
}
