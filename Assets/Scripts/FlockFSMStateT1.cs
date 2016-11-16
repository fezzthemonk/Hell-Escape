using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class is adapted and modified from the FSMT1 implementation class available on UnifyCommunity website
/// The license for the code is Creative Commons Attribution Share Alike.
/// It's originally the port of C++ FSMT1 implementation mentioned in Chapter01 of Game Programming Gems 1
/// You're free to use, modify and distribute the code in any projects including commercial ones.
/// Please read the link to know more about CCA license @http://creativecommons.org/licenses/by-sa/3.0/

/// This class represents the States in the Finite State System.
/// Each state has a Dictionary with pairs (transition-state) showing
/// which state the FSMT1 should be if a transition is fired while this state
/// is the current state.
/// Reason method is used to determine which transition should be fired .
/// Act method has the code to perform the actions the NPC is supposed to do if it큦 on this state.
/// </summary>
public abstract class FlockFSMStateT1
{
    protected Dictionary<FlockTransitionT1, FlockFSMStateT1ID> map = new Dictionary<FlockTransitionT1, FlockFSMStateT1ID>();
    protected FlockFSMStateT1ID stateID;
    public FlockFSMStateT1ID ID { get { return stateID; } }
    protected Vector3 destPos;
    protected Transform[] waypoints;
    protected float curRotSpeed;
    protected float curSpeed;

    public void AddTransition(FlockTransitionT1 transition, FlockFSMStateT1ID id)
    {
        // Check if anyone of the args is invallid
        if (transition == FlockTransitionT1.None || id == FlockFSMStateT1ID.None)
        {
            Debug.LogWarning("FSMStateT1 : Null transition not allowed");
            return;
        }

        //Since this is a Deterministc FSMT1,
        //Check if the current transition was already inside the map
        if (map.ContainsKey(transition))
        {
            Debug.LogWarning("FSMStateT1 ERROR: transition is already inside the map");
            return;
        }

        map.Add(transition, id);
        Debug.Log("Added : " + transition + " with ID : " + id);
    }

    /// <summary>
    /// This method deletes a pair transition-state from this state큦 map.
    /// If the transition was not inside the state큦 map, an ERROR message is printed.
    /// </summary>
    public void DeleteTransition(FlockTransitionT1 trans)
    {
        // Check for NullTransition
        if (trans == FlockTransitionT1.None)
        {
            Debug.LogError("FSMStateT1 ERROR: NullTransition is not allowed");
            return;
        }

        // Check if the pair is inside the map before deleting
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("FSMStateT1 ERROR: TransitionT1 passed was not on this State큦 List");
    }


    /// <summary>
    /// This method returns the new state the FSMT1 should be if
    ///    this state receives a transition  
    /// </summary>
    public FlockFSMStateT1ID GetOutputState(FlockTransitionT1 trans)
    {
        // Check for NullTransition
        if (trans == FlockTransitionT1.None)
        {
            Debug.LogError("FSMStateT1 ERROR: NullTransition is not allowed");
            return FlockFSMStateT1ID.None;
        }

        // Check if the map has this transition
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }

        Debug.LogError("FSMStateT1 ERROR: " + trans+ " TransitionT1 passed to the State was not on the list");
        return FlockFSMStateT1ID.None;
    }

    /// <summary>
    /// Decides if the state should transition to another on its list
    /// NPC is a reference to the npc tha is controlled by this class
    /// </summary>
    public abstract void Reason(Transform player, Transform npc);

    /// <summary>
    /// This method controls the behavior of the NPC in the game World.
    /// Every action, movement or communication the NPC does should be placed here
    /// NPC is a reference to the npc tha is controlled by this class
    /// </summary>
    public abstract void Act(Transform player, Transform npc);

    /// <summary>
    /// Find the next semi-random patrol point
    /// </summary>
    public void FindNextPoint()
    {
        //Debug.Log("Finding next point");
        int rndIndex = Random.Range(0, waypoints.Length);
        Vector3 rndPosition = Vector3.zero;
        destPos = waypoints[rndIndex].position + rndPosition;
    }

    /// <summary>
    /// Check whether the next random position is the same as current tank position
    /// </summary>
    /// <param name="pos">position to check</param>
    protected bool IsInCurrentRange(Transform trans, Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - trans.position.x);
        float zPos = Mathf.Abs(pos.z - trans.position.z);

        if (xPos <= 50 && zPos <= 50)
            return true;

        return false;
    }
}
