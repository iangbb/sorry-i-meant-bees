using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public float mass = 1;
    public float speed = 0;
    Vector2 lastPosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        speed = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
    }
}



