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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
            rb.AddForce(new Vector3(-1, 0, 0) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(right))
            rb.AddForce(new Vector3(1, 0, 0) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(up))
            rb.AddForce(new Vector3(0, 1, 0) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));
        if (Input.GetKey(down))
            rb.AddForce(new Vector3(0, -1, 0) * force / Mathf.Sqrt(rb.velocity.magnitude + 0.01f));

        age += (1 / Mathf.Log10(rb.velocity.magnitude + 2f)) * Time.deltaTime;

        print(rb.velocity.magnitude);
    }

    public float getAge()
    {
        return age;
    }
}
