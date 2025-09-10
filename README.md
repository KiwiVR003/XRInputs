# XRInputs - VR Input Helper

A simple and robust input system for Unity XR (Oculus, Valve Index, etc.)  
Provides easy access to controller buttons, triggers, grips, and thumbsticks with a clean static API.

---

## Hands

Specify which controller/hand to use:

```csharp
XRInputs.Hand left = XRInputs.Hand.Left;
XRInputs.Hand right = XRInputs.Hand.Right;
```

---

## Grip Pressure

Get how much the grip is pressed (0.0 = not pressed, 1.0 = fully pressed):

```csharp
if (XRInputs.GetGripPressure(hand) > 0.5f)
{
    // Grip is pressed more than halfway
    // Perform grab action here
}
```

---

## Trigger Pressure

Get trigger press intensity (0.0 to 1.0):

```csharp
float triggerValue = XRInputs.GetTriggerPressure(XRInputs.Hand.Right);

if (triggerValue > 0.7f)
{
    // Trigger pulled more than 70%
    // Fire weapon or interact
}
```

---

## Buttons (Grip, Trigger, Primary, Secondary)

Check if buttons are pressed (returns `true` if pressed):

```csharp
bool gripDown = XRInputs.GetGripDown(XRInputs.Hand.Left);
bool triggerDown = XRInputs.GetTriggerDown(XRInputs.Hand.Right);
bool primaryDown = XRInputs.GetPrimaryDown(XRInputs.Hand.Left);
bool secondaryDown = XRInputs.GetSecondaryDown(XRInputs.Hand.Right);
```

Example:

```csharp
if (XRInputs.GetPrimaryDown(hand))
{
    // Primary button pressed
    // Jump, select, or trigger an action
}
```

---

## Thumbstick

Get the 2D position of the thumbstick:

```csharp
Vector2 leftStick = XRInputs.GetThumbStick(XRInputs.Hand.Left);

// Example: move player based on thumbstick input
Vector3 move = new Vector3(leftStick.x, 0, leftStick.y);
player.transform.Translate(move * speed * Time.deltaTime);
```

---

## Advantages

- Works with any XR headset supported by Unity XR  
- Static API: call from anywhere  
- Easy to read and maintain  
- Handles all main buttons and axes  
- Singleton instance available if needed  

---

## How to Use

1. Drag `XRInputs.cs` into your Unity project.  
2. Place the XRInputs component on any persistent GameObject (or use static calls).  
3. Call methods anywhere in your code, for example:

```csharp
if (XRInputs.GetGripDown(XRInputs.Hand.Right))
{
    // Do something
}
```

---

## Tips

- Use `GetGripPressure` or `GetTriggerPressure` for analog input  
- Use `GetGripDown` / `GetTriggerDown` for simple on/off button checks  
- Use `GetThumbStick` for movement, teleport, or menu navigation  
- Combine inputs for advanced gestures or interactions  

---

## Examples

```csharp
// Grab with grip
if (XRInputs.GetGripPressure(hand) > 0.5f)
{
    GrabObject();
}

// Fire weapon with trigger
if (XRInputs.GetTriggerDown(hand))
{
    Shoot();
}

// Move player with left thumbstick
Vector2 moveInput = XRInputs.GetThumbStick(XRInputs.Hand.Left);
Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);
player.transform.Translate(moveDir * speed * Time.deltaTime);

// Jump using primary button
if (XRInputs.GetPrimaryDown(hand))
{
    Jump();
}
```

---

## Author
KiwiVR003
Namespace: KiwiVR.XRInputs  

For more VR scripts and Unity examples, see the GitHub repository.
