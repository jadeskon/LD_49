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

	protected Vector3 localRotation;
	protected Quaternion oldRotation;
	protected Vector3 oldPosition;
	public Transform orbit = null;
	public Transform target = null;

	public float cameraDistance = 10f;

	public float orbitDampening = 5f;

	public float orbitFOV = 60;

	// Use this for initialization
	void Start()
	{
		transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		transform.localPosition = new Vector3(0f, 0f, 0f);
		orbit.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		localRotation.y += 90;
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		//zooming
		cameraDistance = Mathf.Clamp(cameraDistance, 0.1f, 40f);
		//actualRotation----------------------------------------------------------
		Quaternion QT = Quaternion.Euler(25f, target.transform.rotation.eulerAngles.y, 0f);
		//Quaternion QT = orbit.transform.localRotation.;
		orbit.transform.localRotation = Quaternion.Slerp(orbit.transform.rotation, QT, Time.deltaTime * orbitDampening);
		orbit.transform.position = Vector3.Lerp(orbit.transform.position, target.transform.position, Time.deltaTime * 50f);


		if (transform.localPosition.z != cameraDistance * -1f)
		{
			transform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(transform.localPosition.z, cameraDistance * -1f, Time.deltaTime * 10));
		}
	}

}
