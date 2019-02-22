using System.Collections;
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

    public bool keys;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
            rb.AddForce(new Vector3(-1, 0, 0) * force);
        if (Input.GetKey(right))
            rb.AddForce(new Vector3(1, 0, 0) * force);
        if (Input.GetKey(up))
            rb.AddForce(new Vector3(0, 1, 0) * force);
        if (Input.GetKey(down))
            rb.AddForce(new Vector3(0, -1, 0) * force);

        age += (1 / (rb.velocity.magnitude + 1)) * Time.deltaTime;
    }

    public float getAge()
    {
        return age;
    }
}
