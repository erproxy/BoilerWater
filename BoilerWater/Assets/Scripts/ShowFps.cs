using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFps : MonoBehaviour {

    public static float fps;
    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = 300;
    }
    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)fps);
    }
}