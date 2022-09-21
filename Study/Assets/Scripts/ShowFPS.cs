using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    float DeltaTime = 0.0f;

    void Update()
    {
        DeltaTime += (Time.deltaTime - DeltaTime) * 0.1f;
    }

    void OnGUI()
    {
        float msec = DeltaTime * 1000.0f;
        float fps = 1.0f / DeltaTime;
        string text = string.Format("{0:0.0}ms, FPS: {1:0.}", msec, fps);

        GUI.Label(new Rect(0, 0, 200, 100), text);
    }
}