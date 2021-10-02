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

    public void ApplyTorqueOnWheel(WheelCollider wheel, float force)
    {
        wheel.motorTorque = force;
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
