using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {
	//Checks for what you have baught
	public GameObject shop;
	public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Keypad1))/*&& this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Rabbit_atk_1"))*/ {

			this.anim.Play("Attack");
		}

	}
}
