using UnityEngine;
using System.Collections;

public class pacdot : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D co) {
		//if the colliding object is pacman, delete pacdot
		if (co.name == "pacman")
			Destroy(gameObject);
	}
}
