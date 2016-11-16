using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class hp : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;
    public int RoD = 5;
    public float healthBarLength;
    public int counter = 2;
    private float cnt = 0;      // Use this for initialization 

    void Start()
    {
        healthBarLength = Screen.width / 2;
    }       // Update is called once per frame 

    void Update()
    {
        if (Time.timeScale != 0) AdjustCurrentHealth(0);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);
    }

    public void AdjustCurrentHealth(int adj)
    {
        /*cnt += 1;
        if (cnt == counter)
        {
            cnt = 0;
            AdjustCurrentHealth(-2);
        }*/
        curHealth += adj;
        if (curHealth < 0)
            curHealth = 0;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
		if (curHealth <= 0) 
		{
			curHealth = 100;
			Application.LoadLevel (1);
		}
          //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
              // Destroy (this.gameObject); 	
        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}