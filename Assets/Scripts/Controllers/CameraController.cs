using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunningAverage
{
    int Count;
    List<float> Values;
    public RunningAverage(int count)
    {
        Count = count;
        Values = new List<float>(count);
    }
    public float Push(float value)
    {
        if (Values.Count == Count)
            Values.RemoveAt(0);
        Values.Add(value);
        return Average();
    }
    public void Clear()
    {
        Values.Clear();
    }
    public float Average() => Values.Average();
}

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
