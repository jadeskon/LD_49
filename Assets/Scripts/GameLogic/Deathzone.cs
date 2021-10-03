using UnityEngine;

public class Deathzone : MonoBehaviour
{
	public string Reason;
	public GameplayEventSystem eventSystem;
	void OnTriggerEnter(Collider collider)
	{
        var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
			eventSystem.GameOver(string.IsNullOrEmpty(Reason) ? "You drowned in the cold sea." : Reason);
	}
}
