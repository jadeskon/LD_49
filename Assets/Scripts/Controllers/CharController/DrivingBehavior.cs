using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingBehavior
{
    private PlayerCharakterController owner;
    private Rigidbody ownRigidbody;
    private DrivingAtributes atributes;
    private WheelSetup wheels;
    public DrivingBehavior(PlayerCharakterController iniOwner, Rigidbody iniRigidbody, DrivingAtributes iniAtributes)
    {
        owner = iniOwner;
        ownRigidbody = iniRigidbody;
        atributes = iniAtributes;
        wheels = owner.GetWheels();
    }

    public void UpdateDrivingBehavior(Vector3 moveDir)
    {
        UpdateSteeringAngle(moveDir);
        UpdateWheelTorque();
    }

    private void UpdateSteeringAngle(Vector2 moveDir)
    {
        Debug.Log(moveDir);

        wheels.frontLeftWheel.steerAngle = atributes.maxSteeringAngle * moveDir.x;
        wheels.frontRightWheel.steerAngle = atributes.maxSteeringAngle * moveDir.x;
    }

    private void UpdateWheelTorque()
    {
        wheels.ApplyTorqueOnWheel(wheels.frontLeftWheel, atributes.maxTorque);
        wheels.ApplyTorqueOnWheel(wheels.frontRightWheel, atributes.maxTorque);
    }
}
