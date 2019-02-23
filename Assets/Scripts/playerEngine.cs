﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float age;

    public KeyCode down;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;

    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(left))
            rb.AddForce(new Vector2(-1, 0) * force * 6 / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(right))
            rb.AddForce(new Vector2(1, 0) * force * 6 / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(up))
            rb.AddForce(new Vector2(0, 1) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(down))
            rb.AddForce(new Vector2(0, -1) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        */

        Vector2 hor = new Vector2(1, 0);
        Vector2 ver = new Vector2(0, 1);
        if (Input.GetKey(left))
            rb.AddForce(-hor * force * Phaser(rb.velocity, -hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(right))
            rb.AddForce(hor * force * Phaser(rb.velocity, hor) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(up))
            rb.AddForce(ver * force * Phaser(rb.velocity, ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(down))
            rb.AddForce(-ver * force * Phaser(rb.velocity, -ver) / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));

        age += (0.5f / Mathf.Log10(rb.velocity.magnitude + 2f)) * Time.deltaTime;
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

}
