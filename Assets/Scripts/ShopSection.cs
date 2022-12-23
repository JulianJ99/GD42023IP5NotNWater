using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSection : MonoBehaviour
{
   public Skin [] miniGameSkins;

   public Skin [] modifiedSkins;
   public Skin [] soapBalancingskins;

   public SkinChanger skinChanger;

   private void OnEnable() {
        if (GameObject.FindGameObjectsWithTag("ShopGlobalManager").Length <= 1)
        {
            DontDestroyOnLoad(this);
            
        } else 
        {
            return;
        }
   }

   private void OnDisable() {
    modifiedSkins = miniGameSkins;
   }

    private void Start()
    {   
        if (modifiedSkins.Length > 0)
        {
            miniGameSkins = modifiedSkins;
        }
        skinChanger = SkinChanger.instance;
        foreach (Skin skin in miniGameSkins)
        {
            skin.CheckSkin();
        }
        foreach (Skin skin in soapBalancingskins)
        {
            skin.CheckSkin();
        }
    }

    public void BuySkin1()
    {
        Shop.BuySkin(miniGameSkins[0]);
    }

    public void BuySkin2()
    {
        Shop.BuySkin(miniGameSkins[1]);
    }

    public void BuySkin3()
    {
        Shop.BuySkin(miniGameSkins[2]);
    }

    public void BuySkin4()
    {
        Shop.BuySkin(soapBalancingskins[0]);
    }

    public void BuySkin5()
    {
        Shop.BuySkin(soapBalancingskins[1]);
    }

    public void BuySkin6()
    {
        Shop.BuySkin(soapBalancingskins[2]);
    }

    public void EquipSkin1()
    {
        foreach (Skin skin in miniGameSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(miniGameSkins[0]);
        skinChanger.ChangeDuckSkin(miniGameSkins[0]);
    }

    public void EquipSkin2()
    {
        foreach (Skin skin in miniGameSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(miniGameSkins[1]);
        skinChanger.ChangeDuckSkin(miniGameSkins[1]);
    }

    public void EquipSkin3()
    {
        foreach (Skin skin in miniGameSkins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(miniGameSkins[2]);
        skinChanger.ChangeDuckSkin(miniGameSkins[2]);
    }

    public void EquipSkin4()
    {
        foreach (Skin skin in soapBalancingskins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(soapBalancingskins[0]);
        skinChanger.ChangeToiletSkin(soapBalancingskins[0]);
    }

    public void EquipSkin5()
    {
        foreach (Skin skin in soapBalancingskins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(soapBalancingskins[1]);
        skinChanger.ChangeToiletSkin(soapBalancingskins[1]);
    }

    public void EquipSkin6()
    {
        foreach (Skin skin in soapBalancingskins)
        {
            if (skin.equiped)
            {
                skin.equiped = false;
                skin.equipedText.text = "EQUIP";
                skin.equipSkin.interactable = true;
            }
        }
        Shop.EquipSkin(soapBalancingskins[2]);
        skinChanger.ChangeToiletSkin(soapBalancingskins[2]);
    }
}
