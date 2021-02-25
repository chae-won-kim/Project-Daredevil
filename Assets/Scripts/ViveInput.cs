using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveInput : MonoBehaviour
{

    //public SteamVR_TrackedObject mTrackedObject = null;
    //public SteamVR_Controller.Device mDevice;
    // a reference to the hand
    //public SteamVR_Input_Sources handType;

    void Awake()
    {
        //mTrackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mDevice = SteamVR_Controller.Input((int)mTrackedObject.index);
        /*
        #region Trigger

        if (mDevice.getTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            print("Trigger down");
        }

        if (mDevice.getTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            print("Trigger up");
        }

        // Value
        Vector2 triggerValue = mDevice.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger);
        #endregion

        #region Grip
        if (mDevice.getPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            print("Grip down");
        }

        if (mDevice.getPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            print("Grip up");
        }

        Vector2 gripValue = mDevice.GetAxis(EVRButtonId.k_EButton_SteamVR_Grip);


        #endregion

        #region Touchpad
        if (mDevice.getPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            print("Touchpad down");
        }

        if (mDevice.getPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            print("Touchpad up");
        }
        Vector2 touchValue = mDevice.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
        */
        //#endregion
    
    }
    /*
    public SteamVR_Action_Single 
    void Update()
    {
        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("Teleport down");
        }

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            print("Grab Pinch up");
        }
    }*/
}
