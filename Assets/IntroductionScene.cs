using UnityEngine;
using System.Collections;

public class IntroductionScene : MonoBehaviour {
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	public GameObject text5;
	public GameObject text6;
	public GameObject text7;
	public GameObject text8;
	public GameObject text9;
	public GameObject text10;
	public GameObject text11;
	public GameObject button;
	public GameObject trigger;
	// Use this for initialization
	void Start () {
		text1.SetActive (false);
		text2.SetActive (false);
		text3.SetActive (false);
		text4.SetActive (false);
		text5.SetActive (false);
		text6.SetActive (false);
		text7.SetActive (false);
		text8.SetActive (false);
		text9.SetActive (false);
		text10.SetActive (false);
		text11.SetActive (false);
		button.SetActive (false);
		trigger.SetActive (true);
		StartCoroutine ("Scene");
	}
	IEnumerator Scene(){
		yield return new WaitForSeconds (2.0f);
		text1.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text1.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text2.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text2.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text3.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text3.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text4.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text4.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text5.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text5.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text6.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text6.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text7.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text7.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text8.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text8.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text9.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text9.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text10.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		text10.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		text11.SetActive (true);
		trigger.SetActive (false);
		yield return new WaitForSeconds (5.0f);
		text11.SetActive (false);
		yield return new WaitForSeconds (2.0f);
		button.SetActive (true);
	}
	public void NextLevel(){
		Application.LoadLevel("LumberJack_World1");
	}
}
