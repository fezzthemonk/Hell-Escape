using UnityEngine;
using System.Collections;

public class FlockBoredStateT1 : FlockFSMStateT1
{


	public FlockBoredStateT1()
    {
		stateID = FlockFSMStateT1ID.Bored;
        play = GameObject.FindGameObjectWithTag("Player").GetComponent<hp>();
        curRotSpeed = 1.0f;
        curSpeed = 1.0f;
       
    }
    float timer = 0;
    float danceMax = 5.0f;
	float dance = 0.0f;
    float MaxTime;
    hp play;
    bool attacking = false;
    bool runonce = true;
    public override void Reason(Transform player, Transform npc)
    {


        if (Vector3.Distance(npc.position, destPos) >= npc.GetComponent <FlockNPCTankControllerT1>().AggroRange+2)
        {
			Debug.Log ("Switch back to Patroling State");
            destPos = npc.GetComponent<FlockNPCTankControllerT1>().WP1.transform.position;
            npc.GetComponent<FlockNPCTankControllerT1>().SetTransition(FlockTransitionT1.LostPlayer);
            runonce = true;
        }
    }
   /* void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
           // play=F.gameObject.GetComponent<hp>();
            //Find
            play.AdjustCurrentHealth(-10);
            Debug.Log("called it");
        }
    }*/
    public override void Act(Transform player, Transform npc)
    {
     

        destPos = player.position;
        if (Vector3.Distance(npc.position, destPos) <= 0.50f)
        {//Do the attacking thing here.
            if (!attacking&&timer<=0)
            { 
                play.AdjustCurrentHealth(-10);
                //curSpeed = 1.0f;
                if (player.position.x > npc.position.x)//JUMP BACK. DAMAGEY STUFF HERE
                {
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(4500, 400), ForceMode2D.Force);
                    player.GetComponent<ParticleSystem>().Play();
                }
                else
                {
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4500, 400), ForceMode2D.Force);
                }
                attacking = true;
                timer = 2;
       
                Debug.Log("Enemy Should Attack");
            }
        }

        if (Vector3.Distance(npc.position, destPos) >= .51f)
        {
            if (attacking)
            {

                Debug.Log("enemy reset");
               // curSpeed = 0.25f;
                attacking = false;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                player.GetComponent<ParticleSystem>().Stop();
            }

        }

        
        if (runonce)
        {

       
        
         
         
            runonce = false;
        }

        //Rotate to the target point (instantly)
        npc.transform.LookAt(destPos);
        /*Quaternion targetRotation = Quaternion.LookAt(destPos - npc.position);
        /*npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed); code that could be used to make the character rotate instead of snap, was buggy so commented out.*/

        //Go Forward
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
       
    }
}
