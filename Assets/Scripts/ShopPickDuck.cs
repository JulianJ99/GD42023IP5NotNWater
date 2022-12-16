using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPickDuck : MonoBehaviour
{
    public Skin [] duckSkins;

    private void Start()
    {
        foreach (Skin skin in duckSkins)
        {
            skin.CheckSkin();
        }
    }

    public void BuySkin1()
    {
        Shop.BuySkin(duckSkins[0]);
    }

    public void BuySkin2()
    {
        Shop.BuySkin(duckSkins[1]);
    }

    public void BuySkin3()
    {
        Shop.BuySkin(duckSkins[2]);
    }

    public void EquipSkin1()
    {
        foreach (Skin skin in duckSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(duckSkins[0]);
    }

    public void EquipSkin2()
    {
        foreach (Skin skin in duckSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(duckSkins[1]);
    }

    public void EquipSkin3()
    {
        foreach (Skin skin in duckSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(duckSkins[2]);
    }
}
