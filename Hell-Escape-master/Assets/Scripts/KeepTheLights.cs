using UnityEngine;
using System.Collections;

public class KeepTheLights : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
     DontDestroyOnLoad(transform.gameObject);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
