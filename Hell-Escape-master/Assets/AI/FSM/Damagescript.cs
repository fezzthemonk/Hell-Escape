using UnityEngine;
using System.Collections;



public class Damagescript : MonoBehaviour {
    public int dmg;
    private hp heal;

    // Use this for initialization
    void Start () {
       if (dmg == 0)
        {
            dmg = 5;
        }
        dmg = dmg * -1;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            heal = other.GetComponent<hp>();
            heal.AdjustCurrentHealth(dmg);

        }

    }
}
