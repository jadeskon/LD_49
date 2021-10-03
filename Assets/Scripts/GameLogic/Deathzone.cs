using UnityEngine;

public class Deathzone : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
        var player = collider.GetComponent<PlayerCharakterController>();
		if (player != null)
		{
			GameOverState.Instance.EndGame();
		}
	}
}
