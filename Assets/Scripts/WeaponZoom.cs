using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    Camera fPCamera;
    FirstPersonController fpController;
    float zoomOutFOV;
    float zoomOutSensitivity;

    bool zoomInToggle = false;

    void Awake() 
    {
        fpController = GetComponentInParent<FirstPersonController>();
        fPCamera = GetComponentInParent<Camera>();
        zoomOutFOV = fPCamera.fieldOfView;
        zoomOutSensitivity = fpController.m_MouseLook.XSensitivity;
    }

    void OnDisable() 
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void ZoomIn()
    {
        zoomInToggle = true;
        fPCamera.fieldOfView = zoomInFOV;
        fpController.m_MouseLook.XSensitivity = zoomInSensitivity;
        fpController.m_MouseLook.YSensitivity = zoomInSensitivity; 
    }

    void ZoomOut()
    {
        zoomInToggle = false;
        fPCamera.fieldOfView = zoomOutFOV;
        fpController.m_MouseLook.XSensitivity = zoomOutSensitivity;
        fpController.m_MouseLook.YSensitivity = zoomOutSensitivity;
    }
}
