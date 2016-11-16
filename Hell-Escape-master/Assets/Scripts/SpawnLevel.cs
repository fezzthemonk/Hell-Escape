using UnityEngine;
using System.Collections;

public class SpawnLevel : MonoBehaviour {
	public int Val = 0;
	private float SPX;
	private float SPY;
	private float SPZ;


	// Use this for initialization
	void Start () {
		
		SPX = this.gameObject.transform.position.x;
		SPY = this.gameObject.transform.position.y;
		SPZ = this.gameObject.transform.position.z;

		Val = Random.Range(1,5);

		switch (Val) {
		case 1:
			Instantiate (Resources.Load ("b1"),new Vector3(SPX,SPY,SPZ),Quaternion.identity);
			break;
		case 2:
			Instantiate (Resources.Load ("b2"),new Vector3(SPX,SPY,SPZ),Quaternion.identity);
			break;
		case 3:
			Instantiate (Resources.Load ("b3"),new Vector3(SPX,SPY,SPZ),Quaternion.identity);
			break;
		case 4:
			Instantiate (Resources.Load ("b4"),new Vector3(SPX,SPY,SPZ),Quaternion.identity);
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp (KeyCode.Return))
			Application.LoadLevel (Application.loadedLevel);
	}
}
