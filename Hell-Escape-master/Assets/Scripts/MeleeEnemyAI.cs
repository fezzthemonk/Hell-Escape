using UnityEngine;
using System.Collections;

public class MeleeEnemyAI : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("TriggerON", false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		anim = GetComponent<Animator>();
		if (other.CompareTag("Player")) {
			anim.Play("EnemyMelee");

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		anim = GetComponent<Animator>();
		if (other.CompareTag("Player")) {
			anim.Play("MainMelee");
		}
	}

}
