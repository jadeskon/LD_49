using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingBehavior
{
    private PlayerCharakterController owner;
    private Rigidbody ownRigidbody;
    private DrivingAtributes atributes;
    private WheelSetup wheels;
    private float deccelerationTime = 0.0f;

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
        UpdateWheelTorque(moveDir);
    }

    private void UpdateSteeringAngle(Vector2 moveDir)
    {
        float steerT = 0.9f;
        if(Mathf.Abs(moveDir.x) > 0.5)
        {
            steerT = 0.99f;
        }
        wheels.frontLeftWheel.steerAngle = Mathf.Lerp(atributes.maxSteeringAngle * moveDir.x, wheels.frontLeftWheel.steerAngle, steerT);
        wheels.frontRightWheel.steerAngle = Mathf.Lerp(atributes.maxSteeringAngle * moveDir.x, wheels.frontLeftWheel.steerAngle, steerT);
    }

    private void UpdateWheelTorque(Vector2 moveDir)
    {
        if (moveDir.y > 0)
        {
            wheels.ReleaseBrake();
            wheels.ApplyAccelerationTorqueOnFrontWheels(atributes.maxTorque);
            deccelerationTime = 0.0f;
        }
        else if (moveDir.y < 0)
        {
            wheels.ReleaseBrake();
            wheels.ApplyAccelerationTorqueOnFrontWheels(-atributes.maxTorque);
            deccelerationTime = 0.0f;
        }
        else
        {
            deccelerationTime += Time.fixedDeltaTime;
            float brakeTorque = atributes.maxBrakeTorque * atributes.deccelerationProfile.Evaluate(deccelerationTime / atributes.timeToStillstand);
            wheels.ApplyBrakeTorqueOnALLWheels(brakeTorque);
        }
        
    }
}
