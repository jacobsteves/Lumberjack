using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {
	public GameObject Enemy;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy (Enemy);
		}
	}
}
