using UnityEngine;
using System.Collections;

public class SimplePatrol : MonoBehaviour//extra variables needs cleaning
{

    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft;       // Define wallLeft
    public float wallRight;      // Define wallRight
    public Vector3 destPos;
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value
    Transform playerTransform;
    private float curRotSpeed;
    public Transform turret { get; set; }
    public Transform bulletSpawnPoint { get; set; }
    protected float shootRate;
    protected float elapsedTime;
    public GameObject Bullet;
    // Use this for initialization



    void Start()
    {
        this.originalX = this.transform.position.x;
       // wallLeft = transform.position.x - 2.5f;
       // wallRight = transform.position.x + 2.5f;
        curRotSpeed = 2.0f;
        turret = gameObject.transform.GetChild(0).transform;
        bulletSpawnPoint = turret.GetChild(0).transform;
        elapsedTime = 0.0f;
        shootRate = 3.0f;



    }

    // Update is called once per frame
    void Update()
    {
   

        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
        


        }
    }
 
   
