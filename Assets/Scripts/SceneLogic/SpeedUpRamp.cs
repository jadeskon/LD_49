using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpRamp : MonoBehaviour
{
    [SerializeField]
    private float speedUpForce = 100.0f;
    private Vector3 speedUpdirection;
    private float coolDownTime = 2.0f;
    private float lastSpeedUpTimeStamp;

    private void Awake()
    {
        lastSpeedUpTimeStamp = Time.realtimeSinceStartup;
        speedUpdirection = transform.TransformDirection(Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && Time.realtimeSinceStartup - lastSpeedUpTimeStamp > coolDownTime)
        {
            lastSpeedUpTimeStamp = Time.realtimeSinceStartup;
            other.attachedRigidbody.velocity += speedUpdirection.normalized * speedUpForce;
        }
    }
}
