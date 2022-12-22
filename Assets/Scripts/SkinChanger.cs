using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
   public GameObject duck;
   public GameObject toilet;

   public static SkinChanger instance;

   private void Awake() {
        if (instance != null)
        {
            return;
        } else {
            instance = this;
        }
   } 

   public void ChangeDuckSkin(Skin newSkin)
    {
        duck.GetComponent<SpriteRenderer>().sprite = newSkin.spriteImage;
        Debug.Log("SKIN CHANGING WORKS");
    }

    public void ChangeToiletSkin(Skin newSkin)
    {
        toilet.GetComponent<Image>().sprite = newSkin.spriteImage;
        Debug.Log("SKIN CHANGING WORKS");
    }
}
