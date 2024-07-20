using Unity.VisualScripting;
using UnityEngine;

public class Boar : MonoBehaviour
{
    Rigidbody2D rb;

    Animator anim;

    PhysicsCheck physicsCheck;

    [Header("基本参数")]
    public float normalspeed;
    //public float chasespeed;
    public float currentspeed;
    public Vector3 faceDirection;

[Header("计时器")]
public float waitTime;

public float waitTimeCounter;

public bool wait;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        physicsCheck = GetComponent<PhysicsCheck>();
        currentspeed = normalspeed;
        waitTimeCounter = waitTime;
    }

    public void Update()
    {
        faceDirection = new Vector3(-transform.localScale.x, 0, 0);
        if (physicsCheck.touchLeftWall && faceDirection.x < 0|| physicsCheck.touchRightWall && faceDirection.x > 0)
        {
            wait = true;
            transform.localScale = new Vector3(faceDirection.x,1,1);
        }

        TimeCounter();
    }


    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(currentspeed * faceDirection.x * Time.deltaTime, rb.velocity.y);
    }

    public void TimeCounter(){
        if(wait){
            waitTimeCounter -= Time.deltaTime;
            if(waitTimeCounter <= 0){
                wait = false;
                waitTimeCounter = waitTime;
                transform.localScale = new Vector3(faceDirection.x,1,1);
            }
        }
    }
}
