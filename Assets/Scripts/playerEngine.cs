using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float age = 21;
    private Animator anim;

    public KeyCode down;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;

    public float force;
    public const float maxSpeed = 8;
    public float ageSpeed = 0.5f; 

    public float collisionTime;
    public float preCollisionTime;
    private bool paralysed;

    private bool correcting;

    private int animLeftId;
    private int animRightId;
    private int animUpId;
    private int animDownId;
    private int animIdleId;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collisionTime = Time.time - 10;
        correcting = false;

        animLeftId = Animator.StringToHash("Left");
        animRightId = Animator.StringToHash("Right");
        animUpId = Animator.StringToHash("Up");
        animDownId = Animator.StringToHash("Down");
        animIdleId = Animator.StringToHash("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        // reset animations
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);

        Vector2 hor = rb.transform.right;
        Vector2 ver = rb.transform.up;

        KeyCode[] arrows = new KeyCode[] { up, down, left, right };
        Vector2[] indications = new Vector2[] { ver, -ver, -hor, hor };
        bool[] pressed = new bool[] { false, false, false, false };


        //get pressed keys
        bool nothing = true;
        for (int i = 0; i < arrows.Length; i++) {
            if (Input.GetKey(arrows[i])) {
                nothing = false;
                pressed[i] = true;
            }
        }

        if (pressed[2]) { //left
            anim.SetBool("Left", true);
            rb.AddForce(-hor * force * Phaser(rb.velocity, -hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[3]) { //right
            anim.SetBool("Right", true);
            rb.AddForce(hor * force * Phaser(rb.velocity, hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[0]) { //up
            anim.SetBool("Up", true);
            rb.AddForce(ver * force * Phaser(rb.velocity, ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[1]) { //down          
            anim.SetBool("Down", true);
            rb.AddForce(-ver * force * Phaser(rb.velocity, -ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }

        if (nothing)
            anim.SetBool("Idle", true);

        age += (ageSpeed / Mathf.Log10(rb.velocity.magnitude + 2f)) * Time.deltaTime;
        rb.freezeRotation = true;

        /*
        correcting = false;
        float time_differential = Time.time - collision_time;
        //if (rb.velocity != Vector2.zero && (time_differential) >= 3) {
        if (rb.velocity != Vector2.zero && (time_differential) > 1.5) {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
            if (correcting) {
                transform.Rotate((Vector3.forward * 5) / ((time_differential + (float)1.5) * (time_differential + (float)1.5)));
                if ((Vector3)(rb.velocity / rb.velocity.magnitude) == transform.rotation * new Vector2(1,1)) {
                    correcting = false;
                    Debug.Log(0);
                }
            } else {
                Vector3 vectorToTarget = rb.velocity - (Vector2)transform.forward;
                float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
            }
            
        } else if (time_differential <= 1.5) {
            transform.Rotate((Vector3.forward * 5) / ((time_differential + (float)1.5) * (time_differential + (float)1.5)));
            correcting = true;
        }
        */
        /*
        float time_differential = Time.time - collision_time;
        if (rb.velocity != Vector2.zero && (time_differential) > 1.5)
        {
            Vector3 vectorToTarget = rb.velocity - (Vector2)transform.forward;
            float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
        }
        else if (time_differential <= 1.5)
        {
            transform.Rotate((Vector3.forward * 5) / ((time_differential + (float)1.5) * (time_differential + (float)1.5)));
        }
        */
        
        float timeDifferential = Time.time - collisionTime;
        Vector3 dir;
        float theta;

        if (rb.velocity != Vector2.zero) {
            Vector3 vectorToTarget = rb.velocity - (Vector2)transform.forward;
            float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            if (angle < 1) {
                correcting = false;
            }
            if (correcting) {
                dir = transform.rotation * new Vector3(1, 1, 1);
                theta = Vector2.Angle(rb.velocity, dir);
                transform.Rotate(new Vector3(0, 0, (float)(angle * Time.deltaTime)));
            } else  {
                transform.Rotate(new Vector3(0, 0, (float)(angle * Time.deltaTime)));
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
            }
        } else if (timeDifferential <= 1) {
            correcting = true;
            transform.Rotate((Vector3.forward * 5) / ((timeDifferential + (float)1.5) * (timeDifferential + (float)1.5)));
        } else if (timeDifferential <= 3.5) {
            dir = transform.rotation * new Vector3(1,1,1);
            theta = Vector2.Angle(rb.velocity, dir);
            transform.Rotate(new Vector3(0,0,(float)(theta / (3.75 - timeDifferential)) * Time.deltaTime));
        }
        

        hardCapSpeed();

    }

    public float getAge()
    {
        return age;
    }

    public int getAgeAnim()
    {
        if (age < 42)
        {
            return 0;
        }
        if((age >= 42.0f) && (age < 60.0f))
        {
            return 1;
        }
        if (age >= 60.0f && age < 84.0f)
        {
            return 2;
        }
        if (age >= 84.0f && age < 98.0f)
        {
            return 3;
        }
        if (age >= 98.0f && age < 115.0f)
        {
            return 4;
        }
        if(age >= 115)
        {
            return 5;
        }
        return 0;

    }

    float Phaser(Vector2 velocity, Vector2 newDirection)
    {
        Vector2 direction = velocity / velocity.magnitude;
        float cos_theta = Vector2.Dot(direction, newDirection) / (direction.magnitude * newDirection.magnitude);
        float theta = Mathf.Acos(cos_theta);
        return 1 + 40 * Mathf.Sin(theta); //CHANGE FOR DIFFERENT ROTATION ABILITY
    }

    public void OnCollisionEnter2D()
    {
        preCollisionTime = collisionTime;
        collisionTime = Time.time;
        rb.velocity /= 4;
        GetComponent<CollisionAudio>().setHit(true);
    }

    private void hardCapSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity *= maxSpeed / rb.velocity.magnitude;
        }
    }

}