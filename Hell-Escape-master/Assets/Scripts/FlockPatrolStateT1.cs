using UnityEngine;
using System.Collections;

public class FlockPatrolStateT1 : FlockFSMStateT1
{
    GameObject TargetTank;
    bool needstomove = false;
   // int waypointsReached;
    int ToggleWP;

    public FlockPatrolStateT1(Transform[] wp) 
    {
        ToggleWP = 0;
        TargetTank = GameObject.FindGameObjectWithTag("Player");
        waypoints = wp;
        stateID = FlockFSMStateT1ID.Patrolling;
       
        curRotSpeed = 1.0f;
        curSpeed = 0.25f;
    }


    public override void Reason(Transform player, Transform npc)
    {
        float dist = Vector3.Distance(player.position, npc.position);
		Debug.Log (dist.ToString);
        //Empty because the transition to the bored (chasing whatever you want to call it) state is handled in the player controller.
        if (dist<= npc.GetComponent<FlockNPCTankControllerT1>().AggroRange)
        {
            npc.GetComponent<FlockNPCTankControllerT1>().SetTransition(FlockTransitionT1.IsBored);
        }

    }


    public override void Act(Transform player, Transform npc)
    {

        if (ToggleWP == 0)
        {
            destPos = npc.GetComponent<FlockNPCTankControllerT1>().WP1.transform.position;
            ToggleWP = 1;
        }
        //Find next patrol point if the current point is reached
        if (Vector3.Distance(npc.position, destPos) <= 2.0f)
        {
        
            switch (ToggleWP)
            {
                case 1:
                    Debug.Log("Reached WP 1");
                    destPos = npc.GetComponent<FlockNPCTankControllerT1>().WP2.transform.position;
                    ToggleWP = 2;
                    break;
                case 2:
                    Debug.Log("Reached WP 2");
                    destPos = npc.GetComponent<FlockNPCTankControllerT1>().WP1.transform.position;
                    ToggleWP = 1;
                    break;
                default:
                    Debug.Log("DestPos Set to unhandled exception, reverting to first waypoint");
                    destPos = npc.GetComponent<FlockNPCTankControllerT1>().WP1.transform.position;
                    ToggleWP = 1;
                    break;
            }
           

        }


        //destPos = TargetTank.transform.position;
        npc.transform.LookAt(destPos);
        //Rotate to the target point
        //Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        //npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //Go Forward
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }
}