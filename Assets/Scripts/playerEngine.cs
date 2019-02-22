using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public float force;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(-1 * rb.transform.right * force);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(rb.transform.right * force);
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(rb.transform.up * force);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(-1 * rb.transform.up * force);

    }
}
