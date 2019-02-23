using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public int mass;
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
        speed = ((Vector2) transform.position - lastPosition).magnitude;
        lastPosition = (Vector2) transform.position;
    }
}



