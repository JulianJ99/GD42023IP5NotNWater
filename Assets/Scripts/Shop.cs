using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Shop
{
    public static void EquipSkin(Skin skin)
    {
        if (!skin.equiped)
        {
            skin.equiped = true;
            skin.equipSkin.interactable = false;
            skin.equipedText.text = "EQUIPED";
           // SkinChanger.ChangeDuckSkin(skin);
        }
    }

    public static void BuySkin(Skin skin)
    {
        if (!skin.purchased)
        {
            Debug.Log("NO");
            if (skin.cost <= PlayersProgress.totalScore)
            {
                Debug.Log("BOUGHT!");
                PlayersProgress.totalScore -= skin.cost;
                skin.purchased = true;
                skin.buySkin.interactable = false;
                skin.equipSkinVisual.SetActive(true);
            }
        }
    }
}
