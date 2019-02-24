using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary_script : MonoBehaviour
{
    private List<Rigidbody2D> bodies;
    private const float boundaryIncrement = 0.2f;

    public int width;
    public int height;

    void Start()
    {
        bodies = new List<Rigidbody2D>();
        foreach (GameObject body in GameObject.FindGameObjectsWithTag("Player"))
        {
            bodies.Add(body.GetComponent<Rigidbody2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody2D rb in bodies)
        {
            Vector3 pos = rb.transform.position;

            if (Mathf.Abs(pos.x) > width / 2)
                rb.transform.position = new Vector3(pos.x * (-1) + (pos.x > 0 ? boundaryIncrement : -boundaryIncrement),
                    pos.y, pos.z);
            if (Mathf.Abs(pos.y) > height / 2)
                rb.transform.position = new Vector3(pos.x,
                    pos.y * (-1) + (pos.y > 0 ? boundaryIncrement : -boundaryIncrement), pos.z);
        }
    }
}