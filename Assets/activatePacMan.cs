using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class activatePacMan : MonoBehaviour {
	public Text enemytalk;
	public Text yourreply;
	public Text run;
	void Start() {
		enemytalk.text = "";
		yourreply.text = "";
		run.text = "";
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (3.0f);
		enemytalk.text = "Enemies: Your house burns down, you endanger and almost kill yourself, and the worst part, you did it only to give us your Mario.";
		yield return new WaitForSeconds (7.0f);
		enemytalk.text = "";
		yourreply.text = "You: And the best part? You think I wont run.";
		run.text = "RUN";
		yield return new WaitForSeconds (4.0f);
		float fadeTime = GameObject.Find ("Pac-man Trigger").GetComponent<fader>().BeginFade (1);
		yield return new WaitForSeconds (fadeTime); //fading
		yield return new WaitForSeconds (5.0f); //this last one is for dramatic effect
		Application.LoadLevel("finalpacman");
	}
	void OnTriggerEnter(Collider other)
	{
		StartCoroutine(Wait());
	}
}
