using UnityEngine;
using System.Collections;

public class LeavingTrigger : MonoBehaviour {
	
	public GameObject TheHouse;
	public GameObject TheBurningHouse;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "FireTrigger") 
		{
			TheBurningHouse.SetActive(false);
			TheHouse.SetActive(true);
		}
	}
}
