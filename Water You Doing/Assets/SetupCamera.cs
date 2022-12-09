using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCamera : MonoBehaviour
{
    void Start()
    {
        Canvas[] canvasses;
        canvasses = GlobalGameManager.Instance.GetComponents<Canvas>();
        foreach (Canvas canvas in canvasses)
        {
            canvas.worldCamera = GetComponent<Camera>();
        }
    }
}
