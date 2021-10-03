using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savezone : MonoBehaviour
{
	public GameplayEventSystem eventSystem;
	void OnTriggerEnter(Collider collider)
	{
		var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
		{
			eventSystem.SaveZoneTrigger(true);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
		{
			eventSystem.SaveZoneTrigger(false);
		}
	}
}
