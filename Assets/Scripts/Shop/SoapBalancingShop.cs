using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoapBalancingShop : MonoBehaviour
{
    public GameObject selectSkinVisualUsualToilet, selectSkinVisualSilverToilet, selectSkinVisualGoldToilet;
    public Button selectSkinUsualToilet, selectSkinSilverToilet, selectSkinGoldToilet;
    public TextMeshProUGUI equipTextUsualToilet, equipTextSilverToilet, equipTextGoldToilet;
    public TextMeshProUGUI priceTextUsualToilet, priceTextSilverToilet, priceTextGoldToilet;
    public Button buySkinUsualToilet, buySkinSilverToilet, buySkinGoldToilet;

    private void Start() {
        selectSkinVisualUsualToilet.SetActive(false);
        selectSkinVisualSilverToilet.SetActive(false);
        selectSkinVisualGoldToilet.SetActive(false);
        priceTextUsualToilet.text = SkinSelection.usualToiletPrice.ToString();
        priceTextSilverToilet.text = SkinSelection.silverToiletPrice.ToString();
        priceTextGoldToilet.text = SkinSelection.goldToiletPrice.ToString();
        CheckSkin();
    }

    private void Update()
    {
        CheckSkin();
    }

    public void CheckSkin()
    {
        if (SkinSelection.usualToiletBought)
        {
            buySkinUsualToilet.interactable = false;
            selectSkinVisualUsualToilet.SetActive(true);
        } if (SkinSelection.silverToiletBought)
        {
            buySkinSilverToilet.interactable = false;
            selectSkinVisualSilverToilet.SetActive(true);
        } if (SkinSelection.goldToiletBought)
        {
            buySkinGoldToilet.interactable = false;
            selectSkinVisualGoldToilet.SetActive(true);
        }

        if (SkinSelection.usualToiletSelected)
        {
            selectSkinUsualToilet.interactable = false;
            equipTextUsualToilet.text = "EQUIPED";
        } if (SkinSelection.silverToiletSelected)
        {
            selectSkinSilverToilet.interactable = false;
            equipTextSilverToilet.text = "EQUIPED";
        } if (SkinSelection.goldToiletSelected)
        {
            selectSkinGoldToilet.interactable = false;
            equipTextGoldToilet.text = "EQUOIPED";
        }

        if (!SkinSelection.usualToiletSelected)
        {
            selectSkinUsualToilet.interactable = true;
            equipTextUsualToilet.text = "EQUIP";
        } if (!SkinSelection.silverToiletSelected)
        {
            selectSkinSilverToilet.interactable = true;
            equipTextSilverToilet.text = "EQUIP";
        } if (!SkinSelection.goldToiletSelected)
        {
            selectSkinGoldToilet.interactable = true;
            equipTextGoldToilet.text = "EQUOIP";
        }
    }
}
