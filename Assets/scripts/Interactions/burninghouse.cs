using UnityEngine;
using System.Collections;

public class burninghouse : MonoBehaviour {

	public GameObject TheHouse;
	public GameObject TheBurningHouse;
	// Use this for initialization
	void Start () {
		TheBurningHouse.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "TheHouse") 
		{
			TheHouse.SetActive(false);
			TheBurningHouse.SetActive(true);
		}
	}
}
