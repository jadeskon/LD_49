using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharakterController : MonoBehaviour
{
    [SerializeField]
    private CharGrafiksController grafiksController;
    [SerializeField]
    private WheelSetup wheels;
    private BoxCollider ownCollider;
    private Rigidbody ownRigidbody;
    [SerializeField]
    private Transform cameraTarget;
    [Header("Atributes"), SerializeField]    
    private DrivingAtributes atributes;
    [SerializeField]
    private SoundEventSystem soundChanel;
    [SerializeField]
    private float grundDetectionLength = 1.5f;

    private DrivingBehavior drivingBehavior;

    private Vector3 grundHitpoint = new Vector3();
    private Vector3 grundHitNormal = new Vector3();

    private Inputs currentInputs;

    private float currentResetCooldownTimer = 0.0f;
    private float resetCooldownTime = 2.0f;

    [SerializeField]
    private AudioSource engineSoundIdle;

    [SerializeField]
    private AudioSource engineSoundLoad;

    private void Awake()
    {
        ownCollider = GetComponent<BoxCollider>();
        ownRigidbody = GetComponent<Rigidbody>();
        drivingBehavior = new DrivingBehavior(this, ownRigidbody, atributes);
        ownRigidbody.centerOfMass = new Vector3(0,-0.5f,0);
    }

    private void Update()
    {
        wheels.UpdateWheelTransforms(wheels.frontLeftWheel, wheels.frontLeftWheelTransform);
        wheels.UpdateWheelTransforms(wheels.frontRightWheel, wheels.frontRightWheelTransform);
        wheels.UpdateWheelTransforms(wheels.backLeftWheel, wheels.backLeftWheelTransform);
        wheels.UpdateWheelTransforms(wheels.backRightWheel, wheels.backRightWheelTransform);
        grafiksController.UpdateGrafiks();

        float engineSpeed = ownRigidbody.velocity.magnitude;

        engineSoundIdle.pitch = Mathf.Max(1,(engineSpeed / 10) % 3);
        engineSoundLoad.pitch = ((engineSpeed / 4) % 2)/3 + 0.5f;

        engineSoundIdle.volume = Mathf.Min(1,1 - (engineSpeed / 2));
        engineSoundLoad.volume = Mathf.Min(1, engineSpeed / 2);

    }

    public void UpdatePlayerController(Inputs newInputs)
    {
        currentInputs = newInputs;
        UpdateRaycasts();
        drivingBehavior.UpdateDrivingBehavior(currentInputs.vector);
        CarTurner(currentInputs.reset);
    }

    private void UpdateGrundRaycast()
    {
        RaycastHit hit;
        Ray grundRay = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(grundRay, out hit, grundDetectionLength))
        {
            grundHitpoint = hit.point;
            grundHitNormal = hit.normal;
        }
        else
        {
            grundHitpoint = Vector3.zero;
            grundHitNormal = Vector3.zero;
        }
    }

    private void UpdateRaycasts()
    {
        UpdateGrundRaycast();
    }

    private void CarTurner(bool carTurningInput)
    {
        currentResetCooldownTimer += Time.fixedDeltaTime;
        if (carTurningInput && currentResetCooldownTimer - resetCooldownTime > 0)
        {
            currentResetCooldownTimer = 0;
            ownRigidbody.MovePosition(transform.position + Vector3.up * 3);
            ownRigidbody.MoveRotation(Quaternion.identity);
        }
    }

    //Getters
    public Vector3 GetNormalOfGrund()
    {
        return grundHitNormal;
    }

    public Vector3 GetGrundHitPoint()
    {
        return grundHitpoint;
    }

    public WheelSetup GetWheels()
    {
        return wheels;
    }
    
    public Vector3 GetCameraTarget()
    {
        return cameraTarget.position;
    }

    public void SetPasengersDisplay(uint newAmountOfPasengers)
    {
        grafiksController.SetAmountDisplayedPasengers(newAmountOfPasengers);
    }

    //Unity Utility
    private void OnCollisionEnter(Collision collision)
    {
        soundChanel.PlaySound((int)SoundEnum.carHit ,Camera.main.GetComponent<AudioSource>());
    }

    //Gizmos
    private void OnDrawGizmos()
    {
        UpdateRaycasts();
        if (GetNormalOfGrund() != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(GetGrundHitPoint(), GetGrundHitPoint() + GetNormalOfGrund());
        }
    }
}
