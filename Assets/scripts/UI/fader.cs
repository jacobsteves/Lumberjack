using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fader : MonoBehaviour {
	public Texture2D fadeOutTexture;     //the texture that will overlay the screen
	public float fadeSpeed = 0.8f; 		 //fading speed

	private int drawDepth = -1000;	     //the draw in heirarchy, so itll render last
	private float alpha = 1.0f;			 
	private int fadeDir = -1; 			 //direction to fade, -1=in, 1=out

	void OnGUI () {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		//set colour of GUI
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth; //make sure texture renders on top
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw tecture
	}

	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}

	//this function is called when a level is loaded, this is to make a fade default when loading a scene
	void OnLevelWasLoaded () {
		BeginFade (-1);
	}
}
