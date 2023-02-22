using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    public Camera FPSCamera;
    public RigidbodyFirstPersonController fpsController;
    public float zoomOutFOV = 60.0f;
    public float zoomInFOV = 20.0f;
    public float zoomOutSensitivity = 2.0f;
    public float zoomInSensitivity = 0.5f;

    private bool zoomToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!zoomToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomToggle = false;
        FPSCamera.fieldOfView = zoomOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomToggle = true;
        FPSCamera.fieldOfView = zoomInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
