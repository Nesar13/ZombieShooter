using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;//regular field
    [SerializeField] float zoomedinFOV = 20f;//using scoop
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    RigidbodyFirstPersonController fpsController;//access to Rigid body for sensitivty
    bool zoomedInToggle = false; //regularly just zoomed out
    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();//get RigidFPS compoennent at start
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;//when clicked toogle switched on and zoom in
                fpsCamera.fieldOfView = zoomedinFOV;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;//x sensitivity when zoomed out
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;//y sensitivity when zoomed out
            }
            else
            {
                zoomedInToggle = false;//when clicked again toogle switched to false
                fpsCamera.fieldOfView = zoomedOutFOV;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;//x sensitivity when zoomed in
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;//y sensitivity when zoomed in
            }
        }
    }
}