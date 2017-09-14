#pragma strict

var track1 : AudioClip;
 var track2 : AudioClip;
 
 GetComponent.<AudioSource>().clip = track1;
 GetComponent.<AudioSource>().Play();
 
 var audio1Volume : float = 1.0;
 var audio2Volume : float = 0.0;
 var track2Playing : boolean = false;
 var fadingout : boolean = false;
 var trigger : GameObject; 
 
 function Update() {
 	if (fadingout == true){
    	 fadeOut();
 	}
     if (fadingout == true && audio1Volume <= 0.1) {
         if(track2Playing == false)
         {
           track2Playing = true;
           GetComponent.<AudioSource>().clip = track2;
           GetComponent.<AudioSource>().Play();
         }
         
         fadeIn();
     }
     if (fadingout == false){
     	fadeIn();
     }
     if (trigger.activeSelf == false) {
        fadeOut();
     }
 }
 function OnTriggerEnter2D (other : Collider2D) {
 	if (other.gameObject.tag == "FadeMusicNow") {
		fadingout = true;
	}
}
 function fadeIn() {
     if (audio2Volume < 1) {
         audio2Volume += 0.1 * Time.deltaTime;
         GetComponent.<AudioSource>().volume = audio2Volume;
     }
 }
 
 function fadeOut() {
     if(audio1Volume > 0.1)
     {
         audio1Volume -= 0.1 * Time.deltaTime;
         GetComponent.<AudioSource>().volume = audio1Volume;
     }
 }