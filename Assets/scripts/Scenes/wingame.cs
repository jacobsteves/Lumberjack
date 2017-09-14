using UnityEngine;
using System.Collections;

public class wingame : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel("marioScene1");
	}
}
