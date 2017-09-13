using UnityEngine;

using System.Collections;

using System.Collections.Generic;



public class newmovement : MonoBehaviour
	
{
	
	/*
 
     This script is used to average the mouse input over x 
 
     amount of frames in order to create a smooth mouselook.
 
     */
	
	
	
	//Mouse look sensitivity
	
	public float sensitivityX = 2f;
	
	public float sensitivityY = 2f;
	
	
	
	//Default mouse sensitivity
	
	public float defaultSensX = 2f;
	
	public float defaultSensY = 2f;
	
	
	
	//Minimum angle you can look up
	
	public float minimumY = -60f;
	
	public float maximumY = 60f;
	
	
	
	//Number of frames to be averaged, used for smoothing mouselook
	
	public int frameCounterX = 35;
	
	public int frameCounterY = 35;
	
	
	
	//Mouse rotation input
	
	private float rotationX = 0f;
	
	private float rotationY = 0f;
	
	
	
	//Used to calculate the rotation of this object
	
	private Quaternion xQuaternion;
	
	private Quaternion yQuaternion;
	
	private Quaternion originalRotation;
	
	
	
	//Array of rotations to be averaged
	
	private List<float> rotArrayX = new List<float> ();
	
	private List<float> rotArrayY = new List<float> ();
	
	
	
	void Start ()
		
	{
		
		//Lock/Hide cursor
		
		Screen.lockCursor = true;
		
		
		
		if (GetComponent<Rigidbody>())
			
			GetComponent<Rigidbody>().freezeRotation = true;
		
		
		
		originalRotation = transform.localRotation;
		
	}
	
	
	
	void Update ()
		
	{
		
		if (Screen.lockCursor) {
			
			//Mouse/Camera Movement Smoothing:    
			
			//Average rotationX for smooth mouselook
			
			float rotAverageX = 0f;
			
			rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
			
			
			
			//Add the current rotation to the array, at the last position
			
			rotArrayX.Add (rotationX);
			
			
			
			//Reached max number of steps?  Remove the oldest rotation from the array
			
			if (rotArrayX.Count >= frameCounterX) {
				
				rotArrayX.RemoveAt (0);
				
			}
			
			
			
			//Add all of these rotations together
			
			for (int i_counterX = 0; i_counterX < rotArrayX.Count; i_counterX++) {
				
				//Loop through the array
				
				rotAverageX += rotArrayX[i_counterX];
				
			}
			
			
			
			//Now divide by the number of rotations by the number of elements to get the average
			
			rotAverageX /= rotArrayX.Count;
			
			
			
			//Average rotationY, same process as above
			
			float rotAverageY = 0;
			
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			rotArrayY.Add (rotationY);
			
			
			
			if (rotArrayY.Count >= frameCounterY) {
				
				rotArrayY.RemoveAt (0);
				
			}
			
			
			
			for (int i_counterY = 0; i_counterY < rotArrayY.Count; i_counterY++) {
				
				rotAverageY += rotArrayY[i_counterY];
				
			}
			
			
			
			rotAverageY /= rotArrayY.Count;
			
			
			
			//Apply and rotate this object
			
			xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
			
			yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
			
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			
		}
		
	}
	
	
	
	private float ClampAngle (float angle, float min, float max)
		
	{
		
		if (angle < -360f)
			
			angle += 360f;
		
		if (angle > 360f)
			
			angle -= 360f;
		
		
		
		return Mathf.Clamp (angle, min, max);
		
	}
}