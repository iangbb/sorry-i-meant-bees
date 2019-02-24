using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public float mass;
    public float speed;
    
    private Vector2 lastPosition = Vector2.zero;
    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        speed = body.velocity.magnitude;
    }
}



