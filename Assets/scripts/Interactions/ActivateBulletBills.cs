using UnityEngine;
using System.Collections;

public class ActivateBulletBills : MonoBehaviour {
	public GameObject BB1;
	public GameObject BB2;
	public GameObject BB3;
	// Use this for initialization
	void Start () {
		BB1.SetActive (false);
		BB2.SetActive (false);
		BB3.SetActive (false);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			BB1.SetActive (true);
			BB2.SetActive (true);
			BB3.SetActive (true);
		}
	}
}
