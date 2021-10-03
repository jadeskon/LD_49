using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character; // The car object
    public GameObject vulcan; // The vulcan, or more generrall, the object thats always in view.
    public float Offset; // Distance of the camera behind the car.
    public float Height; // Dinstance of the camera above the car

    public void LateUpdate()
    {
        var worldVulcanToCarVector = (character.transform.position - vulcan.transform.position).normalized;
        var worldCarToCamera = worldVulcanToCarVector * Offset + Vector3.up * Height;
        transform.position = character.transform.position + worldCarToCamera;
        transform.LookAt(character.transform);
    }
}
