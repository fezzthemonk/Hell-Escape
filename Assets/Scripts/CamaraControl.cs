using UnityEngine;
using System.Collections;

public class CamaraControl : MonoBehaviour {
	private float shift = 12;
	private int min = -20;
	private int max = 12;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//shift = 348.3f;
		//Camera.main.transform.rotation = Quaternion.Euler (0f, shift, 0f);
		if (Input.GetKey(KeyCode.A) && shift > min) {
				shift -= 0.6f;
			Camera.main.transform.rotation = Quaternion.Euler (13.229f, shift, 359.5192f);
			if(shift < min)
				shift = min;
			Camera.main.transform.rotation = Quaternion.Euler (13.229f, shift, 359.5192f);
			} 
		if (Input.GetKey(KeyCode.D) && shift < max) {
			shift += 0.6f;
			Camera.main.transform.rotation = Quaternion.Euler (13.229f, shift, 359.5192f);
			if(shift > max)
				shift = max;
			Camera.main.transform.rotation = Quaternion.Euler (13.229f, shift, 359.5192f);
		} 


	}
}
