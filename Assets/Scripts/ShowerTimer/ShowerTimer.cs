using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowerTimer : MonoBehaviour
{

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endVerticalPosistion = Vector3.zero;
    private Vector3 objPosition = Vector3.zero;


    private bool horizontalMove = true;
    


    public GameObject timerscript;
    float showertimer;
    

    //used for scaling difficulty
    float difficulty;
    float difficultyScaling = 0.2f;

    public GameObject gameManagement;

    private TouchController controls;



    bool isFirstTouch = true;
    public bool isTouched = false;

    private void Awake()
    {
        //gameManagement = GameObject.FindGameObjectWithTag("gamemanager");
        this.startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        
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
    // Start is called before the first frame update
    void Start()
    {
        difficulty = GlobalGameManager.Instance.difficulty;

        this.startPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        TimerScript timer = timerscript.GetComponent<TimerScript>();
        showertimer = timer.timer;
        Debug.Log(showertimer);

        //If the screen's touched, the shower curtains will open, "ending" the game
        if (isTouched)
        {
            Debug.Log("Touched!");
            if((showertimer <= 6) && (showertimer >= 4) ){
                GlobalGameManager.Instance.WinGame();
                Debug.Log("You win!");
            }
            else{
                GlobalGameManager.Instance.LoseGame();
                Debug.Log("You lose.");
            }
        }

        if (showertimer<= 8){
            //Fog 1, best way to implement this would be to change the image of the GameObject for the windows with a second version that's slightly foggy
        }

        if (showertimer <= 6){
            //Fog 2, best way to implement this would be to change the image of the GameObject for the windows with a third version that's even more foggy
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
