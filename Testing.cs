using UnityEngine;
using KiwiVR.XRInput;

public class Testing : MonoBehaviour
{

    public XRInputs.Hand hand;
    

    void Update()
    {
        if (XRInputs.GetGripPressure(hand) > 0.5f)
        {
            
        }

    }
}
