using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour {

    private float fps;

    private float minfps=120;

    [SerializeField] private Text _textFps;
    [SerializeField] private Text _textFpsmin;
    private Text _textCash;
    
    private void Update()
    {
        fps = 1.0f / Time.deltaTime;
        if(minfps>=fps)
        {
            minfps = fps;
           // GUILayout.Label("FPS: " + (int) minfps);
           _textFpsmin.text = minfps.ToString();
        }

        _textFps.text = fps.ToString();
    }

    void Awake()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = 60;

        
    }
    
    void OnGUI()
    {

    }
}