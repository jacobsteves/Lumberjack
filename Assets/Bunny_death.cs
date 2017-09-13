using UnityEngine;
using System.Collections;

public class Bunny_death : MonoBehaviour {
	public GameObject Bunny; 

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Destroy (Bunny);
		}
	}
}
