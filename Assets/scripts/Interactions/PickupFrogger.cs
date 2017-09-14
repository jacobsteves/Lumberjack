using UnityEngine;
using System.Collections;

public class PickupFrogger : MonoBehaviour {
	public GameObject Frogger;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("v")){
			Frogger.SetActive (false);
		}
	}
}
