using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpUponStart : MonoBehaviour {
	public Text startupHelp;
	// Use this for initialization
	void Start () {
		StartCoroutine ("help");
	}
	IEnumerator help(){
		yield return new WaitForSeconds (4.0f);
		startupHelp.text = "";
	}
}
