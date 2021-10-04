using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrificezone : MonoBehaviour
{
	public GameplayEventSystem eventSystem;
	void OnTriggerEnter(Collider collider)
	{
		var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
        {
			eventSystem.InfoPopupTrigger("Make a sacrifice to the mountain GOD!!! (press Space)");
			eventSystem.SacrifizeZoneTrigger(true);
        }
	}

	void OnTriggerExit(Collider collider)
	{
		var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
		{
			eventSystem.InfoPopupTrigger("");
			eventSystem.SacrifizeZoneTrigger(false);
		}
	}
}
