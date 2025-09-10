using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.InputFeatureUsage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.XR;

namespace KiwiVR.XRInput
{

    public class XRInputs : MonoBehaviour
    {
        
        public static XRInputs Instance { get; private set; }

        public enum Hand { Left, Right }

        

        private static XRNode GetXRNode(Hand hand)
        {
        return hand == Hand.Left ? XRNode.LeftHand : XRNode.RightHand;
        }

        public static float GetGripPressure(Hand hand)
        {
        XRNode node = GetXRNode(hand);
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);

        if (device.isValid && device.TryGetFeatureValue(CommonUsages.grip, out float value))
        return value;

        return 0f;
        }

        public static float GetTriggerPressure(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.trigger, out float value))
                return value;
            return 0f;
        }
        
        public static bool GetGripDown(Hand hand)
        {
        XRNode node = GetXRNode(hand);
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);

        if (device.isValid && device.TryGetFeatureValue(CommonUsages.gripButton, out bool value))
            return value;

        return false;
        }

        public static bool GetTriggerDown(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.triggerButton, out bool value))
                return value;
            return false;
        }

        public static bool GetPrimaryDown(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.primaryButton, out bool value))
                return value;
            return false;
        }

        public static bool GetSecondaryDown(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool value))
                return value;
            return false; 
        }

        public static bool GetPrimaryTouched(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.primaryTouch, out bool value))
                return value;
            return false;
        }

        public static bool GetSecondaryTouched(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool value))
                return value;
            return false; 
        }

        public static Vector2 GetThumbStick(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 value))
                return value;
            return Vector2.zero;
        }

        public static bool GetThumbStickTouched(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool value))
                return value;
            return false;
        }

        public static bool GetThumbStickDown(Hand hand)
        {
            XRNode node = GetXRNode(hand);
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.isValid && device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool value))
                return value;
            return false;
        }

    private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
