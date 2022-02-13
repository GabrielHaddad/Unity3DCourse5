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
        fpController = GetComponent<FirstPersonController>();
        fPCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomInToggle)
            {
                zoomInToggle = true;
                zoomOutFOV = fPCamera.fieldOfView;
                fPCamera.fieldOfView = zoomInFOV;
                zoomOutSensitivity = fpController.m_MouseLook.XSensitivity;
                fpController.m_MouseLook.XSensitivity = zoomInSensitivity;
                fpController.m_MouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                zoomInToggle = false;
                fPCamera.fieldOfView = zoomOutFOV;
                fpController.m_MouseLook.XSensitivity = zoomOutSensitivity;
                fpController.m_MouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }
}
