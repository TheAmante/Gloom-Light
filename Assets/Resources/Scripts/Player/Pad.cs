﻿using UnityEngine;
using System.Collections;

public class Pad : Controller
{
    public int joystickNumber = 1;
    string joystickString;

    public override void updateControll()
    { }

    public override Vector3 getDisplacement()
    {
        joystickString = joystickNumber.ToString();

        movementVector.x = Input.GetAxis("LeftJoystickX_p" + joystickString) * movementSpeed;
        movementVector.z = Input.GetAxis("LeftJoystickY_p" + joystickString) * movementSpeed;

        return movementVector;
    }

    public override Vector2 getAngleTorchlight()
    {
        joystickString = joystickNumber.ToString();

        aimVector.x = Input.GetAxis("RightJoystickX_p" + joystickString);
        aimVector.y = Input.GetAxis("RightJoystickY_p" + joystickString);

        return aimVector;
    }

    public override bool getInteractInput()
    {
        joystickString = joystickNumber.ToString();
        return Input.GetButtonDown("InteractButton_p" + joystickString);
    }

    public override bool getLightInput()
    {
        joystickString = joystickNumber.ToString();
        return (Input.GetAxis("LightButton_p" + joystickString) != 0);
    }
}