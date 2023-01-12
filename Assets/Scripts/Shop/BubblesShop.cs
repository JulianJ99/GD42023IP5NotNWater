using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubblesShop : MonoBehaviour
{
    public GameObject selectSkinVisualWoodenBack, selectSkinVisualMountainBack, selectSkinVisualCityBack;
    public Button selectSkinWoodenBack, selectSkinMountainBack, selectSkinCityBack;
    public TextMeshProUGUI equipTextWoodenBack, equipTextMountainBack, equipTextCityBack;
    public TextMeshProUGUI priceTextWoodenBack, priceTextMountainBack, priceTextCityBack;
    public Button buySkinWoodenBack, buySkinMountainBack, buySkinCityBack;

    private void Start() {
        selectSkinVisualWoodenBack.SetActive(false);
        selectSkinVisualMountainBack.SetActive(false);
        selectSkinVisualCityBack.SetActive(false);
        priceTextWoodenBack.text = SkinSelection.woodenBackgroundPrice.ToString();
        priceTextMountainBack.text = SkinSelection.mountainsBackgroundPrice.ToString();
        priceTextCityBack.text = SkinSelection.cityBackgroundPrice.ToString();
        CheckSkin();
    }

    private void Update()
    {
        CheckSkin();
    }

    public void CheckSkin()
    {
        if (SkinSelection.woodenBackgroundBought)
        {
            buySkinWoodenBack.interactable = false;
            selectSkinVisualWoodenBack.SetActive(true);
        } if (SkinSelection.mountainsBackgroundBought)
        {
            buySkinMountainBack.interactable = false;
            selectSkinVisualMountainBack.SetActive(true);
        } if (SkinSelection.cityBackgroundBought)
        {
            buySkinCityBack.interactable = false;
            selectSkinVisualCityBack.SetActive(true);
        }

        if (SkinSelection.woodenBackgroundSelected)
        {
            selectSkinWoodenBack.interactable = false;
            equipTextWoodenBack.text = "EQUIPED";
        } if (SkinSelection.mountainsBackgroundSelected)
        {
            selectSkinMountainBack.interactable = false;
            equipTextMountainBack.text = "EQUIPED";
        } if (SkinSelection.cityBackgroundSelected)
        {
            selectSkinCityBack.interactable = false;
            equipTextCityBack.text = "EQUOIPED";
        }

        if (!SkinSelection.woodenBackgroundSelected)
        {
            selectSkinWoodenBack.interactable = true;
            equipTextWoodenBack.text = "EQUIP";
        } if (!SkinSelection.mountainsBackgroundSelected)
        {
            selectSkinMountainBack.interactable = true;
            equipTextMountainBack.text = "EQUIP";
        } if (!SkinSelection.cityBackgroundSelected)
        {
            selectSkinCityBack.interactable = true;
            equipTextCityBack.text = "EQUOIP";
        }
    }
}
