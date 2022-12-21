using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSection : MonoBehaviour
{
   public Skin [] miniGameSkins;

   public SkinChanger skinChanger;

   private void OnEnable() {
    if (SkinDTO.skins != null)
    {
        miniGameSkins = SkinDTO.skins;
        Debug.Log(miniGameSkins[1]);
    }
   }

   private void OnDisable() {
    SkinDTO.skins = miniGameSkins;
   }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        skinChanger = SkinChanger.instance;
        foreach (Skin skin in miniGameSkins)
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
}
