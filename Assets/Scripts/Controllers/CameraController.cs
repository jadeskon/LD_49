using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
public class CameraController : MonoBehaviour
{
    public GameObject character; // The car object
    private Transform lookAtTarget;
    public GameObject vulcan; // The vulcan, or more generrall, the object thats always in view.
    public float Offset; // Distance of the camera behind the car.
    public float Height; // Dinstance of the camera above the car
    private RunningAverage averageSpeed = new RunningAverage(30);

	public static float Sigmoid(float value) {
        return 1.0f / (1.0f + (float)System.Math.Exp(-value));
	}
    public void LateUpdate()
    {
        if (character != null)
        {
            var characterSpeed = Vector3.Scale(character.GetComponent<Rigidbody>().velocity, new Vector3(1, 0.1f, 1)).magnitude;
            var averagedSpeed = averageSpeed.Push(characterSpeed);
            var scale = 1 + Sigmoid((averagedSpeed - 10) * 0.3f);

            var worldVulcanToCarVector = (character.transform.position - vulcan.transform.position).normalized;
            var worldCarToCamera = worldVulcanToCarVector * Offset + Vector3.up * Height;
            transform.position = character.transform.position + scale * worldCarToCamera;
            transform.LookAt(lookAtTarget);
        }        
    }

    public void SetCameraTarget(Transform target)
    {
        lookAtTarget = target;
        character = target.GetComponentInParent<PlayerCharakterController>().gameObject;
    }
}
*/

public class CameraController : MonoBehaviour
{
    protected Vector3 localRotation;
    protected Quaternion oldRotation;
    protected Vector3 oldPosition;
    [SerializeField]
    protected Transform orbit = null;
    [SerializeField]
    protected Transform target = null;
    [SerializeField]
    protected Transform volcano = null;
    [SerializeField]
    Rigidbody characterRB = null;

    [SerializeField]
    protected float cameraDistance = 30f;

    [SerializeField]
    protected float orbitDampening = 5f;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        orbit.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        localRotation.y += 90;
    }

    public static float Sigmoid(float value)
    {
        return 1.0f / (1.0f + (float)System.Math.Exp(-value));
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            //zooming
            float velocity = characterRB.velocity.magnitude;
            float scale = Sigmoid((velocity - 2) * 0.1f);
            cameraDistance = Mathf.Clamp(scale * 40, 10f, 40f);

            //actualRotation----------------------------------------------------------
            Quaternion QTForward = Quaternion.Euler(25f, target.transform.rotation.eulerAngles.y, 0f);
            Vector3 volano_direction = volcano.position - transform.position;
            float distance = volano_direction.magnitude;
            volano_direction.y = -50;
            Quaternion QTVolcano = Quaternion.LookRotation(volano_direction, new Vector3(0,1,0));

            float cameraSwitch = Mathf.Clamp((distance - 100) / 100,0,1);
            //Quaternion QT = orbit.transform.localRotation.;

            orbit.transform.localRotation = Quaternion.Slerp(orbit.transform.rotation, Quaternion.Slerp(QTVolcano, QTForward, cameraSwitch), Time.deltaTime * orbitDampening);
            orbit.transform.position = Vector3.Lerp(orbit.transform.position, target.transform.position, Time.deltaTime * 50f);


            if (transform.localPosition.z != cameraDistance * -1f)
            {
                transform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(transform.localPosition.z, cameraDistance * -1f, Time.deltaTime * 10));
            }

        }
    }

    public void SetCameraTarget(Transform target_n)
    {
        target = target_n;
        characterRB = target.GetComponentInParent<PlayerCharakterController>().gameObject.GetComponent<Rigidbody>();
    }

}