using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Controller : MonoBehaviour
{
    Vector3 acceleration;
    private TextMeshProUGUI accTextX;
    private TextMeshProUGUI accTextY;
    private TextMeshProUGUI accTextZ;

    // private float AccelerometerUpdateInterval = 1.0f / 60.0f;
    // private float LowPassKernelWidthInSeconds = 1.0f;
    private float LowPassFilterFactor = 20.0f / 60.0f; // tweakable
    private Vector3 lowPassValue = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        accTextX = GameObject.FindWithTag("X-Acceleration").GetComponent<TextMeshProUGUI>();
        accTextY = GameObject.FindWithTag("Y-Acceleration").GetComponent<TextMeshProUGUI>();
        accTextZ = GameObject.FindWithTag("Z-Acceleration").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Input.acceleration;
        lowPassValue = LowPassFilterAccelerometer(acceleration);
        accTextX.SetText("X-Acceleration: " + Math.Round(acceleration.x, 3) + "\nLowpass: " + Math.Round(lowPassValue.x, 3));
        accTextY.SetText("Y-Acceleration: " + Math.Round(acceleration.y, 3) + "\nLowpass: " + Math.Round(lowPassValue.y, 3));
        accTextZ.SetText("Z-Acceleration: " + Math.Round(acceleration.z, 3) + "\nLowpass: " + Math.Round(lowPassValue.z, 3));
        
    }

    Vector3 LowPassFilterAccelerometer(Vector3 lowPassValue) {
        lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
        return lowPassValue;
    }
}
