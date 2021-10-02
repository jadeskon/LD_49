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
    [Range(-1.0f, 1.0f)]
    public float dirX = 0.0f; 
    public Vector3 moveDir = new Vector3();

    [Header("Atributes"), SerializeField]    
    private DrivingAtributes atributes;
    [SerializeField]
    private float grundDetectionLength = 1.5f;

    private DrivingBehavior drivingBehavior;

    private Vector3 grundHitpoint = new Vector3();
    private Vector3 grundHitNormal = new Vector3();

    private Inputs currentInputs;

    private void Awake()
    {
        ownCollider = GetComponent<BoxCollider>();
        ownRigidbody = GetComponent<Rigidbody>();
        drivingBehavior = new DrivingBehavior(this, ownRigidbody, atributes);
    }

    private void Update()
    {
        wheels.UpdateWheelTransforms(wheels.frontLeftWheel, wheels.frontLeftWheelTransform);
        wheels.UpdateWheelTransforms(wheels.frontRightWheel, wheels.frontRightWheelTransform);
        wheels.UpdateWheelTransforms(wheels.backLeftWheel, wheels.backLeftWheelTransform);
        wheels.UpdateWheelTransforms(wheels.backRightWheel, wheels.backRightWheelTransform);
        grafiksController.UpdateGrafiks();
    }

    public void UpdatePlayerController(Inputs newInputs)
    {
        currentInputs = newInputs;
        UpdateRaycasts();
        moveDir.x = dirX;
        drivingBehavior.UpdateDrivingBehavior(currentInputs.vector);
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
