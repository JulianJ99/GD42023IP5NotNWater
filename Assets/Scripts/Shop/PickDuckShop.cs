using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickDuckShop : MonoBehaviour
{
    public GameObject selectSkinVisualUsualDuck, selectSkinVisualPurpleDuck, selectSkinVisualDuckWithGlasses;
    public Button selectSkinUsualDuck, selectSkinPurpleDuck, selectSkinDuckWithGlasses;
    public TextMeshProUGUI equipTextUsualDuck, equipTextPurpleDuck, equipTextDuckWithGlasses;
    public TextMeshProUGUI priceTextUsualDuck, priceTextPurpleDuck, priceTextDuckWithGlasses;
    public Button buySkinUsualDuck, buySkinPurpleDuck, buySkinDuckWithGlasses;

    private void Start() {
        selectSkinVisualUsualDuck.SetActive(false);
        selectSkinVisualPurpleDuck.SetActive(false);
        selectSkinVisualDuckWithGlasses.SetActive(false);
        priceTextUsualDuck.text = SkinSelection.usualDuckPrice.ToString();
        priceTextPurpleDuck.text = SkinSelection.purpleDuckPrice.ToString();
        priceTextDuckWithGlasses.text = SkinSelection.duckWithGlassesPrice.ToString();
        CheckSkin();
    }

    private void Update()
    {
        CheckSkin();
    }

    public void CheckSkin()
    {
        if (SkinSelection.usualDuckBought)
        {
            buySkinUsualDuck.interactable = false;
            selectSkinVisualUsualDuck.SetActive(true);
        } if (SkinSelection.purpleDuckBought)
        {
            buySkinPurpleDuck.interactable = false;
            selectSkinVisualPurpleDuck.SetActive(true);
        } if (SkinSelection.duckWithGlassesBought)
        {
            buySkinDuckWithGlasses.interactable = false;
            selectSkinVisualDuckWithGlasses.SetActive(true);
        }

        if (SkinSelection.usualDuckSelected)
        {
            selectSkinUsualDuck.interactable = false;
            equipTextUsualDuck.text = "EQUIPED";
        } if (SkinSelection.purpleDuckSelected)
        {
            selectSkinPurpleDuck.interactable = false;
            equipTextPurpleDuck.text = "EQUIPED";
        } if (SkinSelection.duckWithGlassesSelected)
        {
            selectSkinDuckWithGlasses.interactable = false;
            equipTextDuckWithGlasses.text = "EQUOIPED";
        }

        if (!SkinSelection.usualDuckSelected)
        {
            selectSkinUsualDuck.interactable = true;
            equipTextUsualDuck.text = "EQUIP";
        } if (!SkinSelection.purpleDuckSelected)
        {
            selectSkinPurpleDuck.interactable = true;
            equipTextPurpleDuck.text = "EQUIP";
        } if (!SkinSelection.duckWithGlassesSelected)
        {
            selectSkinDuckWithGlasses.interactable = true;
            equipTextDuckWithGlasses.text = "EQUOIP";
        }
    }
}
