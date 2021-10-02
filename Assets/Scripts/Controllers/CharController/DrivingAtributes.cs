using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Atributes/DrivingAtributes")]
public class DrivingAtributes : ScriptableObject
{
    public float maxSteeringAngle = 60;
    public float maxTorque = 300.0f;
    public float timeToMaxTorque = 2.0f;
    public AnimationCurve accelerationProfile;

}
