using UnityEngine;
using System.Collections;

public class FlockNPCTankControllerT1 : FlockAdvancedFSMT1 
{
    public GameObject Bullet;
    public int health;
    public int ammo;
    public float TimeSpent;//tracks time spent in a state
    public int WPDistX,WPDistY,WPDistZ;
    public int WP2DistX, WP2DistY, WP2DistZ,AggroRange;
   public GameObject WP1, WP2;    
    //Repair Zone
    public GameObject Zone;

    public GameObject RelZone1, RelZone2, RelZone3;

    // If in repair state, can't be damaged
    public bool inZone;

    //distance from center to repair from
    public float repdist;
    public int reldist;
    
    //Initialize the Finite state machine for the NPC tank
    protected override void Initialize()
    {
        WP1 = new GameObject("WP1");
        // WP1.AddComponent<Transform>();
        WP1.tag = "WandarPoint";
        WP1.transform.position = new Vector3(gameObject.transform.position.x + WPDistX, gameObject.transform.position.y+WPDistY, gameObject.transform.position.z+WPDistZ);
        WP2 = new GameObject("WP2");
        WP2.tag = "WandarPoint";
        // WP2.AddComponent<Transform>();
        WP2.transform.position = new Vector3(gameObject.transform.position.x - WP2DistX, gameObject.transform.position.y - WP2DistY, gameObject.transform.position.z - WP2DistZ);
        elapsedTime = 0.0f;

        //Get the target enemy(Player)
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;

        if (!playerTransform)
            print("Player doesn't exist.. Please add one with Tag named 'Player'");

        //Get the turret of the tank

        //Start Doing the Finite State Machine
        ConstructFSM();
    }

    //Update each frame
    protected override void FSMUpdate()
    {
        //Check for health
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        elapsedTime += Time.deltaTime;
    }

    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(playerTransform, transform);
        CurrentState.Act(playerTransform, transform);
    }

    public void SetTransition(FlockTransitionT1 t) 
    { 
        PerformTransition(t); 
    }

    private void ConstructFSM()
    {
        //Get the list of points
        pointList = GameObject.FindGameObjectsWithTag("WandarPoint");

        Transform[] waypoints = new Transform[pointList.Length];
        int i = 0;
        foreach(GameObject obj in pointList)
        {
            waypoints[i] = obj.transform;
            i++;
        }

        FlockPatrolStateT1 patrol = new FlockPatrolStateT1(waypoints);
        patrol.AddTransition(FlockTransitionT1.IsBored, FlockFSMStateT1ID.Bored);

        FlockBoredStateT1 bored = new FlockBoredStateT1();
        bored.AddTransition(FlockTransitionT1.LostPlayer, FlockFSMStateT1ID.Patrolling);
        
        AddFSMState(patrol);
        AddFSMState(bored);
        
    }
}
