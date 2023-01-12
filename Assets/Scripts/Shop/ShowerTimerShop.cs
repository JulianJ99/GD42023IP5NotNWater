using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowerTimerShop : MonoBehaviour
{
    public GameObject selectSkinVisualRoseCurtains, selectSkinVisualFootballCurtains, selectSkinVisualUkrainianCurtains;
    public Button selectSkinRoseCurtains, selectSkinFootballCurtains, selectSkinUkrainianCurtains;
    public TextMeshProUGUI equipTextRoseCurtains, equipTextFootballCurtains, equipTextUkrainianCurtains;
    public TextMeshProUGUI priceTextRoseCurtains, priceTextFootballCurtains, priceTextUkrainianCurtains;
    public Button buySkinRoseCurtains, buySkinFootballCurtains, buySkinUkrainianCurtains;

    private void Start() {
        selectSkinVisualRoseCurtains.SetActive(false);
        selectSkinVisualFootballCurtains.SetActive(false);
        selectSkinVisualUkrainianCurtains.SetActive(false);
        priceTextRoseCurtains.text = SkinSelection.roseCurtainsPrice.ToString();
        priceTextFootballCurtains.text = SkinSelection.footballCurtainsPrice.ToString();
        priceTextUkrainianCurtains.text = SkinSelection.ukrainianCurtainsPrice.ToString();
        CheckSkin();
    }

    private void Update()
    {
        CheckSkin();
    }

    public void CheckSkin()
    {
        if (SkinSelection.roseCurtainsBought)
        {
            buySkinRoseCurtains.interactable = false;
            selectSkinVisualRoseCurtains.SetActive(true);
        } if (SkinSelection.footballCurtainsBought)
        {
            buySkinFootballCurtains.interactable = false;
            selectSkinVisualFootballCurtains.SetActive(true);
        } if (SkinSelection.ukrainianCurtainsBought)
        {
            buySkinUkrainianCurtains.interactable = false;
            selectSkinVisualUkrainianCurtains.SetActive(true);
        }

        if (SkinSelection.roseCurtainsSelected)
        {
            selectSkinRoseCurtains.interactable = false;
            equipTextRoseCurtains.text = "EQUIPED";
        } if (SkinSelection.footballCurtainsSelected)
        {
            selectSkinFootballCurtains.interactable = false;
            equipTextFootballCurtains.text = "EQUIPED";
        } if (SkinSelection.ukrainianCurtainsSelected)
        {
            selectSkinUkrainianCurtains.interactable = false;
            equipTextUkrainianCurtains.text = "EQUOIPED";
        }

        if (!SkinSelection.roseCurtainsSelected)
        {
            selectSkinRoseCurtains.interactable = true;
            equipTextRoseCurtains.text = "EQUIP";
        } if (!SkinSelection.footballCurtainsSelected)
        {
            selectSkinFootballCurtains.interactable = true;
            equipTextFootballCurtains.text = "EQUIP";
        } if (!SkinSelection.ukrainianCurtainsSelected)
        {
            selectSkinUkrainianCurtains.interactable = true;
            equipTextUkrainianCurtains.text = "EQUOIP";
        }
    }
}
