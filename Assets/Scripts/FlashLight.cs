using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minumumAngle = 4f;

    Light myLight;
    float originalIntensity;
    float originalAngle;

    private void Awake() 
    {
        myLight = GetComponent<Light>();
    }

    void Start() 
    {
        originalIntensity = myLight.intensity;
        originalAngle = myLight.spotAngle;
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLight()
    {
        myLight.spotAngle = originalAngle;
        myLight.intensity = originalIntensity;

    }

    void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0) return;

        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minumumAngle) return;

        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
}
