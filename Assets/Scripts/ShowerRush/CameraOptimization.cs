using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOptimization : MonoBehaviour
{
    private float screenHeight = 374;
    private float screenWidth = 875;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (screenHeight != Screen.height || screenWidth != Screen.width)
        {
            float currentRatio = screenWidth / screenHeight;
            Debug.Log(currentRatio);
            float newRatio = Screen.width * 1f / Screen.height * 1f;
            Debug.Log(newRatio);
            float rescalingSize = currentRatio / newRatio;
            Debug.Log(rescalingSize);
            FindObjectOfType<Camera>().orthographicSize *= rescalingSize;
            screenHeight = Screen.height;
            screenWidth = Screen.width;
        }
    }
}
