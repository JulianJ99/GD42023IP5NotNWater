using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelection : MonoBehaviour
{
    public static bool usualDuckSelected = true, usualToiletSelected = true, woodenBackgroundSelected = true, roseCurtainsSelected = true;
    public static bool  purpleDuckSelected, duckWithGlassesSelected, silverToiletSelected,
    goldToiletSelected, mountainsBackgroundSelected, cityBackgroundSelected, footballCurtainsSelected, ukrainianCurtainsSelected;

    public static bool usualDuckBought = true, usualToiletBought = true, woodenBackgroundBought = true, roseCurtainsBought = true;

    public static bool purpleDuckBought, duckWithGlassesBought, silverToiletBought,
    goldToiletBought, mountainsBackgroundBought, cityBackgroundBought, footballCurtainsBought, ukrainianCurtainsBought;
    public static int usualDuckPrice = 0;
    public static int usualToiletPrice = 0;
    public static int woodenBackgroundPrice = 0;
    public static int roseCurtainsPrice = 0;
    public static int purpleDuckPrice = 75;
    public static int silverToiletPrice = 75;
    public static int mountainsBackgroundPrice = 75;
    public static int footballCurtainsPrice = 75;
    public static int duckWithGlassesPrice = 125;
    public static int goldToiletPrice = 125;
    public static int cityBackgroundPrice = 125;
    public static int ukrainianCurtainsPrice = 125;

    public void SelectUsualDuck()
    {
        usualDuckSelected = true;
        purpleDuckSelected = false;
        duckWithGlassesSelected = false;
    }

    public void SelectPurpleDuck()
    {
        usualDuckSelected = false;
        purpleDuckSelected = true;
        duckWithGlassesSelected = false;
    }

    public void SelectDuckWithGlasses()
    {
        usualDuckSelected = false;
        purpleDuckSelected = false;
        duckWithGlassesSelected = true;
    }

    public void SelectUsualToilet()
    {
        usualToiletSelected = true;
        silverToiletSelected = false;
        goldToiletSelected = false;
    }

    public void SelectSilverToilet()
    {
        usualToiletSelected = false;
        silverToiletSelected = true;
        goldToiletSelected = false;
    }

    public void SelectGoldToilet()
    {
        usualToiletSelected = false;
        silverToiletSelected = false;
        goldToiletSelected = true;
    }

    public void SelectWoodenBackground()
    {
        woodenBackgroundSelected = true;
        mountainsBackgroundSelected = false;
        cityBackgroundSelected = false;
    }

    public void SelectMountainsBackground()
    {
        woodenBackgroundSelected = false;
        mountainsBackgroundSelected = true;
        cityBackgroundSelected = false;
    }

    public void SelectCityBackground()
    {
        woodenBackgroundSelected = false;
        mountainsBackgroundSelected = false;
        cityBackgroundSelected = true;
    }

    public void SelectRoseCurtains()
    {
        roseCurtainsSelected = true;
        footballCurtainsSelected = false;
        ukrainianCurtainsSelected = false;
    }

    public void SelectFootballCurtains()
    {
        roseCurtainsSelected = false;
        footballCurtainsSelected = true;
        ukrainianCurtainsSelected = false;
    }

    public void SelectUkrainianCurtains()
    {
        roseCurtainsSelected = false;
        footballCurtainsSelected = false;
        ukrainianCurtainsSelected = true;
    }

    public void BuyUsualDuck()
    {
        if (usualDuckBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= usualDuckPrice)
            {
                PlayersProgress.totalScore -= usualDuckPrice;
                usualDuckBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyPurpleDuck()
    {
        if (purpleDuckBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= purpleDuckPrice)
            {
                PlayersProgress.totalScore -= purpleDuckPrice;
                purpleDuckBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyDuckWithGlasses()
    {
        if (duckWithGlassesBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= duckWithGlassesPrice)
            {
                PlayersProgress.totalScore -= duckWithGlassesPrice;
                duckWithGlassesBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyUsualToilet()
    {
        if (usualToiletBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore
                >= usualToiletPrice)
            {
                PlayersProgress.totalScore -= usualToiletPrice;
                usualToiletBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuySilverToilet()
    {
        if (silverToiletBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= silverToiletPrice)
            {
                PlayersProgress.totalScore -= silverToiletPrice;
                silverToiletBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyGoldToilet()
    {
        if (goldToiletBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= goldToiletPrice)
            {
                PlayersProgress.totalScore -= goldToiletPrice;
                goldToiletBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyWoodenBackground()
    {
        if (woodenBackgroundBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= woodenBackgroundPrice)
            {
                PlayersProgress.totalScore -= woodenBackgroundPrice;
                woodenBackgroundBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyMountainsBackground()
    {
        if (mountainsBackgroundBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= mountainsBackgroundPrice)
            {
                PlayersProgress.totalScore -= mountainsBackgroundPrice;
                mountainsBackgroundBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyCityBackground()
    {
        if (cityBackgroundBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= cityBackgroundPrice)
            {
                PlayersProgress.totalScore -= cityBackgroundPrice;
                cityBackgroundBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyRoseCurtains()
    {
        if (roseCurtainsBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= roseCurtainsPrice)
            {
                PlayersProgress.totalScore -= roseCurtainsPrice;
                roseCurtainsBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyFootballCurtains()
    {
        if (footballCurtainsBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= footballCurtainsPrice)
            {
                PlayersProgress.totalScore -= footballCurtainsPrice;
                footballCurtainsBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }

    public void BuyUkrainianCurtains()
    {
        if (ukrainianCurtainsBought)
        {
            Debug.Log("Item already bought!");
            return;
        } else {
            if (PlayersProgress.totalScore >= ukrainianCurtainsPrice)
            {
                PlayersProgress.totalScore -= ukrainianCurtainsPrice;
                ukrainianCurtainsBought = true;
            } else 
            {
                //display error
                return;
            }
        }
    }
}
