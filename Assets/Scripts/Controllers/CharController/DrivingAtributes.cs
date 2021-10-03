using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Atributes/DrivingAtributes")]
public class DrivingAtributes : ScriptableObject
{
    public float maxSteeringAngle = 60;
    public float maxTorque = 20000.0f;
    public float maxBrakeTorque = 2000000.0f;
    public float timeToMaxTorque = 2.0f;
    public AnimationCurve accelerationProfile;
    public float timeToStillstand = 2.0f;
    public AnimationCurve deccelerationProfile;
}
