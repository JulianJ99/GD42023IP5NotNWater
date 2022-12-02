using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowerTimer : MonoBehaviour
{
    [SerializeField] private Vector3 h_endPoint = Vector3.zero;
    [SerializeField] private Vector3 v_endPoint = Vector3.zero;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endVerticalPosistion = Vector3.zero;
    private Vector3 objPosition = Vector3.zero;
    public Sprite open;


    public float verticalMoveSpeed = 1f;
    public float horizontalMoveSpeed = 0.5f;

    //used for scaling difficulty
    float difficulty;
    float difficultyScaling = 0.2f;

    public GameObject gameManagement;

    private TouchController controls;
    bool isFirstTouch = true;

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
        this.h_endPoint = this.GetRelativeEndpoint();
    }

    // Update is called once per frame
    void Update()
    {
        //If the screen's touched, the shower curtains will open, "ending" the game
        if (isTouched)
        {
            if(timer = <5f){
                GlobalGameManager.Instance.WinGame();
            }
            else(){
                GlobalGameManager.Instance.LoseGame();
            }
        }

    }


    public void ScreenIsTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isFirstTouch)
            {
                isFirstTouch = false;
            }
            else
            {
                isTouched = true;
                this.objPosition = this.GetObjectPosition();
                this.endVerticalPosistion = this.GetRelativeVerticalEndpoint();
            }
        }
    }


    public void ResetStartPosition()
    {

    }

}
