using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;

    // [SerializeField] float zoomedOutFOV = 40;
    // [SerializeField] float zoomedInFOV = 20;
    [SerializeField] float zoomOutSensitivity = 5f;
    [SerializeField] float zoomInSensitivity = .5f;


    bool zoomedInToggle = false;

    void OnDisable()
    {
        ZoomOut();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.m_Lens.FieldOfView = 20;
        fpsController.RotationSpeed = zoomInSensitivity;
        fpsController.SpeedChangeRate = 5f;
    }
    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.m_Lens.FieldOfView = 40;
        fpsController.RotationSpeed = zoomOutSensitivity;
        fpsController.SpeedChangeRate = 10f;
    }

}
