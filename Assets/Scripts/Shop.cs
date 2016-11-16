using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {
	public Text Setp;
    private hp heal;
    private int cost;
    GameObject plyr;
    /*

		Use read in scripts to set the values and set what you can buy.
		Deactive = 0, able to buy unable to use. Active = 1, able to use unable to buy.

	*/

    // use code variables, first 3 letters of corisponding function.
    public int Ifr = 0;
	public int Lep = 0;
	public int Con = 0;
	public int Res = 0;
	public int Zyp = 0;
	public int Sea = 0;
	public int Pri = 0;
	public int Env = 0;
	public int Wra = 0;
	public int Slo = 0;
	public int Gre = 0;
	public int Glu = 0;
	public int Lus = 0;

	public GameObject PL;
	//Purchase Functions
	public void Ifrit()
	{
		if ( Ifr == 0)
        {
            cost = -200;
            heal = PL.GetComponent<hp>();
            heal.AdjustCurrentHealth(cost);
            Setp.text = "Purchased";
            Ifr = 1;
        }

	}

    public void LapusLazuli()
    {
		if (Lep == 0)
        {
          cost = -150;
          heal = PL.GetComponent<hp>();
          heal.AdjustCurrentHealth(cost);
    }
        Setp.text = "Purchased";
		Lep = 1;
	}

	public void Container()
	{
        if (Con == 0)
        {
            cost = -500;
            heal = PL.GetComponent<hp>();
            heal.AdjustCurrentHealth(cost);
        }
        Setp.text = "Purchased";
		Con = 1;
	}

	public void Reservoir()
	{
		if (Res == 0)
		{
			cost = -1500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Res = 1;
	}

	public void Zypher()
	{
		if (Zyp == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Zyp = 1;
	}

	public void SealOfSolomon()
	{
		if (Sea == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Sea = 1;
	}

	public void Pride()
	{
		if (Pri == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Pri = 1;
	}

	public void Wrath()
	{
		if (Wra == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Wra = 1;
	}

	public void Sloth()
	{
		if (Slo == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Slo = 1;
	}

	public void Greed()
	{
		if (Gre == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Gre = 1;
	}

	public void Gluttony()
	{
		if (Glu == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Glu = 1;
	}

	public void Lust()
	{
		if (Lus == 0)
		{
			cost = -500;
			heal = PL.GetComponent<hp>();
			heal.AdjustCurrentHealth(cost);
		}
		Setp.text = "Purchased";
		Lus = 1;
	}
}
