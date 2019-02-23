using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float age;
    private Animator anim;

    public KeyCode down;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;

    public float force;
    public const float maxSpeed = 8;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (Input.GetKey(left))
        {
            anim.SetBool("Left", true);
            rb.AddForce(-hor * force * Phaser(rb.velocity, -hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (Input.GetKey(right))
        {
            anim.SetBool("Right", true);
            rb.AddForce(hor * force * Phaser(rb.velocity, hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (Input.GetKey(up))
        {
            anim.SetBool("Up", true);
            rb.AddForce(ver * force * Phaser(rb.velocity, ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        if (Input.GetKey(down))
        {
            anim.SetBool("Down", true);
            rb.AddForce(-ver * force * Phaser(rb.velocity, -ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        }
        age += (0.5f / Mathf.Log10(rb.velocity.magnitude + 2f)) * Time.deltaTime;
        if (!anim.GetBool("Left") && !anim.GetBool("Right") && !anim.GetBool("Up") && !anim.GetBool("Down"))
            anim.SetBool("Idle", true);

        hardCapSpeed();
    }

    public float getAge()
    {
        return age;
    }

    float Phaser(Vector2 velocity, Vector2 new_direction){
        Vector2 direction = velocity / velocity.magnitude;
        float cos_theta = Vector2.Dot(direction, new_direction) / (direction.magnitude * new_direction.magnitude);
        float theta = Mathf.Acos(cos_theta);
        return 1 + 10 * Mathf.Sin(theta);
    }

    private void hardCapSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity * (maxSpeed / rb.velocity.magnitude);
        }
    }
}
