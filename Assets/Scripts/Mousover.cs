using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mousover : MonoBehaviour {

	public Text Displaytext;


	public GameObject ShopCon;
	// Use this for initialization
	void Start () {

		Displaytext.text = "";

	}
	
	// Update is called once per frame
	void Update () {


	}

	//Activate / Deactivate Shop
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			ShopCon.SetActive(true);
		}
	}


	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			ShopCon.SetActive (false);
		}
	}


	//Hover button info

	public void Ifrit()
	{
		
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Ifr == 0) {
			Displaytext.text = "Fires a projectile at enemys. Cost: 200 souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void LepusLazuli()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Lep == 0) {
			Displaytext.text = "DoubleJump. Cost: 150 souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Container()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Con == 0) {
			Displaytext.text = "Double your max health. Cost: 500 souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Reservoir()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Res == 0) {
			Displaytext.text = "Quadruple your max health, but lower your speed. Cost: 1500 souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Zypher()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Zyp == 0) {
			Displaytext.text = "Increase your movement speed. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void SealOfSolomon()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Sea == 0) {
			Displaytext.text = "Gain a random boost every level. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Pride()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Pri == 0) {
			Displaytext.text = "Charge attack that roots enemys for a short time. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Envy()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Env == 0) {
			Displaytext.text = "Souls will slowly move to you after you kill an enemy. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Wrath()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Wra == 0) {
			Displaytext.text = "You deal more damage with greater knockback. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Sloth()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Slo == 0) {
			Displaytext.text = "Slows enemys when hit. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Greed()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Gre == 0) {
			Displaytext.text = "Send out a gold warrior killing enemys in your path. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Gluttony()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Glu == 0) {
			Displaytext.text = "Double the souls enemys drop on death. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}

	public void Lust()
	{
		if (GameObject.Find ("ShopCanvas").GetComponent<Shop>().Lus == 0) {
			Displaytext.text = "Create a ranged wall attack using your souls. Cost: --- souls.";
		} else {
			Displaytext.text = "Purchased";
		}
	}
	public void Return()
	{
		Displaytext.text = ""; 
	}



	//On click button funtions

}
