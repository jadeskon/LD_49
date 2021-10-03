using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class  WheelSetup
{
    public WheelCollider frontRightWheel;
    public Transform frontRightWheelTransform;
    public WheelCollider frontLeftWheel;
    public Transform frontLeftWheelTransform;
    public WheelCollider backRightWheel;
    public Transform backRightWheelTransform;
    public WheelCollider backLeftWheel; 
    public Transform backLeftWheelTransform;

    public void ApplyAccelerationTorqueOnWheel(WheelCollider wheel, float force)
    {
        wheel.motorTorque = force;
    }

    public void ApplyAccelerationTorqueOnALLWheels(float force)
    {
        ApplyAccelerationTorqueOnWheel(frontLeftWheel, force);
        ApplyAccelerationTorqueOnWheel(frontRightWheel, force);
        ApplyAccelerationTorqueOnWheel(backRightWheel, force);
        ApplyAccelerationTorqueOnWheel(backLeftWheel, force);
    }

    public void ApplyBrakeTorqueOnWheel(WheelCollider wheel, float force)
    {
        wheel.brakeTorque = force;
    }

    public void ApplyBrakeTorqueOnALLWheels(float force)
    {
        ApplyBrakeTorqueOnWheel(frontLeftWheel, force);
        ApplyBrakeTorqueOnWheel(frontRightWheel, force);
        ApplyBrakeTorqueOnWheel(backRightWheel, force);
        ApplyBrakeTorqueOnWheel(backLeftWheel, force);
    }

    public void ReleaseBrake()
    {
        frontRightWheel.brakeTorque = 0;
        frontLeftWheel.brakeTorque = 0;
        backRightWheel.brakeTorque = 0;
        backLeftWheel.brakeTorque = 0;
    }

    public void UpdateWheelTransforms(WheelCollider wheel, Transform wheelTransform)
    {
        Vector3 pos = wheelTransform.position;
        Quaternion rot = wheelTransform.rotation;

        wheel.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
