using UnityEngine;

public class Deathzone : MonoBehaviour
{
	public GameplayEventSystem eventSystem;
	void OnTriggerEnter(Collider collider)
	{
        var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
		{
			eventSystem.GameOver();
		}
	}
}
