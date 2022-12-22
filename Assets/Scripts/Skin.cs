using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Skin
{
    public string name;
    public int cost;
    public Sprite spriteImage;
    public bool equiped;
    public bool purchased;
    [SerializeField]
    public TextMeshProUGUI equipedText;
    [SerializeField]
    public TextMeshProUGUI costText;
    public Button buySkin;
    public GameObject equipSkinVisual;
    public Button equipSkin;

    public void CheckSkin() {
        if (!purchased)
        {
            equipSkinVisual.SetActive(false);
        } else {
            buySkin.interactable = false;
        }
        if (equiped)
        {
            equipedText.text = "EQUIPED";
            equipSkin.interactable = false;
        } else {
            equipedText.text = "EQUIP";
        }
        costText.text = cost.ToString();
    }
}
