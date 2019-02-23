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

    public float collision_time;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collision_time = Time.time - (float)1.5;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);

        Vector2 hor = new Vector2(1, 0);
        Vector2 ver = new Vector2(0, 1);

        KeyCode[] arrows = new KeyCode[] { up, down, left, right };
        Vector2[] indications = new Vector2[] { ver, -ver, -hor, hor };
        bool[] pressed = new bool[] { false, false, false, false };
        Vector2 to_go_vec = new Vector2(0, 0);

        bool nothing = true;
        for (int i = 0; i < arrows.Length; i++) {
            if (Input.GetKey(arrows[i])) {
                nothing = false;
                pressed[i] = true;
                to_go_vec += indications[i];
            }
        }

        float to_go_dir = Vector2.Angle(rb.velocity, to_go_vec);
        Vector3 cross = Vector3.Cross(rb.velocity, to_go_vec);

        if (cross.z > 0)
            to_go_dir = 360 - to_go_dir;



        if (!nothing) {
            if (to_go_dir <= 67.5 || to_go_dir >= 292.5)
            {
                anim.SetBool("Up", true);
            }
            if (to_go_dir >= 22.5 && to_go_dir <= 157.5)
            {
                anim.SetBool("Right", true);
            }
            if (to_go_dir >= 202.5 && to_go_dir <= 337.5)
            {
                anim.SetBool("Left", true);
            }
        }


        if (pressed[2])
        {
            rb.AddForce(-hor * force * Phaser(rb.velocity, -hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[3])
        {
            rb.AddForce(hor * force * Phaser(rb.velocity, hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[0])
        {
            rb.AddForce(ver * force * Phaser(rb.velocity, ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (pressed[1])
        {
            rb.AddForce(-ver * force * Phaser(rb.velocity, -ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        age += (ageSpeed / Mathf.Log10(rb.velocity.magnitude + 2f)) * Time.deltaTime;
        if (!anim.GetBool("Left") && !anim.GetBool("Right") && !anim.GetBool("Up") && !anim.GetBool("Down"))
            anim.SetBool("Idle", true);

        float time_differential = Time.time - collision_time;
        if (rb.velocity != Vector2.zero && (time_differential) > 1.5) {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
            Vector3 vectorToTarget = rb.velocity - (Vector2)transform.forward;
            float angle = Mathf.Atan2(-vectorToTarget.x, vectorToTarget.y) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
        } else if (time_differential <= 1.5) {
            transform.Rotate((Vector3.forward * 5) / ((time_differential + (float)1.5) * (time_differential + (float)1.5)));
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

    float Phaser(Vector2 velocity, Vector2 new_direction)
    {
        Vector2 direction = velocity / velocity.magnitude;
        float cos_theta = Vector2.Dot(direction, new_direction) / (direction.magnitude * new_direction.magnitude);
        float theta = Mathf.Acos(cos_theta);
        return 1 + 10 * Mathf.Sin(theta);
    }

    public void OnCollisionEnter2D()
    {
        collision_time = Time.time;
        rb.velocity /= 4;
    }

    private void hardCapSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity * (maxSpeed / rb.velocity.magnitude);
        }
    }

}