using UnityEngine;
using System.Collections;

public class StartFading : MonoBehaviour {
	public GameObject trigger;
	// Use this for initialization
	void Start () {
		trigger.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			trigger.SetActive (false);
		}
	}
}
