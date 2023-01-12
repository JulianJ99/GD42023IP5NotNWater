using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipeScript : MonoBehaviour
{
    float[] rotations = {0, 90, 270}; //weird error: when rotating on 180, sometimes doesnt count as correctly rotated when it is so
    [SerializeField]
    bool placedCorrectly = false;
    public float[] correctRotations;
    public int possibleRotations = 1;
    public PipeConnectorManger pipeConnectorManger;

    private void Awake()
    {
        pipeConnectorManger = GameObject.Find("GameManager").GetComponent<PipeConnectorManger>();
    }

    private void Start()
    {
        int random = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[random]);

        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotations[0] || transform.eulerAngles.z == correctRotations[1])
            {
                placedCorrectly = true;
                pipeConnectorManger.CorrectMove();
            }
        } else
        {
            if (transform.eulerAngles.z == correctRotations[0])
            {
                placedCorrectly = true;
                pipeConnectorManger.CorrectMove();
            }
        }
    }

    // public void ScreenIsTouch(InputAction.CallbackContext context)
    // {
    //     if (context.started)
    //     {
    //         transform.Rotate(new Vector3(0, 0, 90));
    //     }
    // }

    public void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotations[0] || transform.eulerAngles.z == correctRotations[1] && placedCorrectly == false)
            {
                placedCorrectly = true;
                pipeConnectorManger.CorrectMove();
            } else if (placedCorrectly)
            {
                placedCorrectly = false;
                pipeConnectorManger.WrongMove();
            }
        } else 
        {
            if (transform.eulerAngles.z == correctRotations[0] && placedCorrectly == false)
            {
                placedCorrectly = true;
                pipeConnectorManger.CorrectMove();
            } else if (placedCorrectly)
            {
                placedCorrectly = false;
                pipeConnectorManger.WrongMove();
            }
        }
    }
}