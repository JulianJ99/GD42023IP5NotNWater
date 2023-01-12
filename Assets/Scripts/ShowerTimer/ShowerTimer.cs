using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class ShowerTimer : MonoBehaviour
{

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endVerticalPosistion = Vector3.zero;
    private Vector3 objPosition = Vector3.zero;

    public Image foggySurroundings;
    public float maximumFogPercentage = 155;
    private bool horizontalMove = true; 
    
    public float winGameThresholdMax = 0.5f;
    /*minimum amount of time that should pass from the start of the level
    (as a percentage from total time for the level) for the player to win */
    public float winGameThresholdMin = 0.25f;
    /* after this point pressing on the screen would lose the game*/
    public float fogFirstTrigger = 0.8f; //percentage from the total time for the level, when the first visual effect would be shown
    public float fogSecondTrigger = 0.55f; //same but with second visual effect (fog)
    private float currentFogPercentage = 0;
    float showertimer;

    private float timeToCompleteLevel; //total time for completing the level, including difficulty scaling
    //used for scaling difficulty

    public GameObject canvas;
    GameManagementV2 localManager;
  
    private TouchController controls;
    public Sprite GAMESTART, FOG1, FOG2, GAMEEND;
    //skins
    bool roseCurtainsSelected, footballCurtaisSelected, ukrainianCurtainsSelected;
    public GameObject roseCurtains, footballCurtains, ukrainianCurtains;
    public Sprite GAMESTARTSkin1, FOG1Skin1, FOG2Skin1, GAMEENDSkin1;
    public Sprite GAMESTARTSkin2, FOG1Skin2, FOG2Skin2, GAMEENDSkin2;

    bool isFirstTouch = true;
    public bool keepTiming = true;
    public bool isTouched = false;
 
    private void Awake()
    {
        //gameManagement = GameObject.FindGameObjectWithTag("gamemanager");
        this.startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (roseCurtainsSelected == true)
        {
            Sprite GAMESTART = Resources.Load<Sprite>("showertimerbgclosed");  
            Sprite FOG1 = Resources.Load<Sprite>("showertimerbgclosed1");    
            Sprite FOG2 = Resources.Load<Sprite>("showertimerbgclosed2");  
            Sprite GAMEEND = Resources.Load<Sprite>("showertimerbg");
        } else if (footballCurtaisSelected == true)
        {
            Sprite GAMESTARTSkin1 = Resources.Load<Sprite>("opencurtainsfootball");  
            Sprite FOG1Skin1 = Resources.Load<Sprite>("opencurtainsfootballfog1");    
            Sprite FOG2Skin1 = Resources.Load<Sprite>("opencurtainsfootballfog2");  
            Sprite GAMEENDSkin1 = Resources.Load<Sprite>("closedcurtainsfootball");
        } else if (ukrainianCurtainsSelected == true)
        {
            Sprite GAMESTARTSkin2 = Resources.Load<Sprite>("opencurtainsukraine");  
            Sprite FOG1Skin2 = Resources.Load<Sprite>("opencurtainsukrainefog1");    
            Sprite FOG2Skin2 = Resources.Load<Sprite>("opencurtainsukrainefog2");  
            Sprite GAMEENDSkin2 = Resources.Load<Sprite>("closedcurtainsukraine");
        } else 
        {
            Sprite GAMESTART = Resources.Load<Sprite>("showertimerbgclosed");  
            Sprite FOG1 = Resources.Load<Sprite>("showertimerbgclosed1");    
            Sprite FOG2 = Resources.Load<Sprite>("showertimerbgclosed2");  
            Sprite GAMEEND = Resources.Load<Sprite>("showertimerbg");
        }

        controls = new TouchController();
        //controls.Touch.TouchPosition.performed += ctx => ScreenIsTouch();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public float FogIncrease()
    {
        float fogIncrease = maximumFogPercentage / (timeToCompleteLevel * 12);
        return fogIncrease;
    }
    // Start is called before the first frame update
    void Start()
    {
        roseCurtainsSelected = SkinSelection.roseCurtainsSelected;
        footballCurtaisSelected = SkinSelection.footballCurtainsSelected;
        ukrainianCurtainsSelected = SkinSelection.ukrainianCurtainsSelected;

         if (roseCurtainsSelected == true)
        {
            roseCurtains.SetActive(true);
            footballCurtains.SetActive(false);
            ukrainianCurtains.SetActive(false);
        } else if (footballCurtaisSelected == true)
        {
            roseCurtains.SetActive(false);
            footballCurtains.SetActive(true);
            ukrainianCurtains.SetActive(false);
        } else if (ukrainianCurtainsSelected == true)
        {
            roseCurtains.SetActive(false);
            footballCurtains.SetActive(false);
            ukrainianCurtains.SetActive(true);
        } else 
        {
            roseCurtains.SetActive(true);
            footballCurtains.SetActive(false);
            ukrainianCurtains.SetActive(false);
        }

        localManager = FindObjectOfType<GameManagementV2>();
        this.startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        timeToCompleteLevel = localManager.calculatedTimeForLvl;
    }

    private void FixedUpdate()
    {
        currentFogPercentage += FogIncrease();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToCompleteLevel == 1000)
        {
            timeToCompleteLevel = localManager.calculatedTimeForLvl;
        }
        Stopwatch currentTimer = FindObjectOfType<GameManagementV2>().levelTimer;
        showertimer = timeToCompleteLevel - currentTimer.ElapsedMilliseconds;

        //If the screen's touched, the shower curtains will open, "ending" the game
        if (isTouched && currentTimer.IsRunning)
        {
            keepTiming = false;
            if (roseCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = GAMEEND;
                Debug.Log("Touched!");
            } else if (footballCurtaisSelected)
            {
                canvas.GetComponent<Image>().sprite = GAMEENDSkin1;
                Debug.Log("Touched!");
            } else if (ukrainianCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = GAMEENDSkin2;
                Debug.Log("Touched!");
            } else
            {
                canvas.GetComponent<Image>().sprite = GAMEEND;
                Debug.Log("Touched!");
            }

            if((showertimer <= timeToCompleteLevel * winGameThresholdMax) &&
                (showertimer >= timeToCompleteLevel * winGameThresholdMin) ){

                localManager.WinGame();
                Debug.Log("You win!");
                isTouched = false;
            }
            else{

                localManager.LoseGame();
                Debug.Log("You lose.");
                isTouched = false;
            }
        }
        foggySurroundings.GetComponent<Image>().color = new Color(183, 183, 183, currentFogPercentage);
        if ((showertimer<= timeToCompleteLevel * fogFirstTrigger) && keepTiming == true){
            //Fog 1, best way to implement this would be to change the image of the GameObject for the windows with a second version that's slightly foggy
            if (roseCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG1;
            } else if (footballCurtaisSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG1Skin1;
            } else if (ukrainianCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG1Skin2;
            } else
            {
                canvas.GetComponent<Image>().sprite = FOG1;
            }
        }

        if ((showertimer <= timeToCompleteLevel * fogSecondTrigger) && keepTiming == true){
            //Fog 2, best way to implement this would be to change the image of the GameObject for the windows with a third version that's even more foggy
            if (roseCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG2;
            } else if (footballCurtaisSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG2Skin1;
            } else if (ukrainianCurtainsSelected)
            {
                canvas.GetComponent<Image>().sprite = FOG2Skin2;
            } else 
            {
                canvas.GetComponent<Image>().sprite = FOG2;
            }
        }
    }

    public void ScreenIsTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Touched!");
            if (isFirstTouch)
            {
                isFirstTouch = false;
            }
            else
            {
                isTouched = true;
            }
        }
    }

}
