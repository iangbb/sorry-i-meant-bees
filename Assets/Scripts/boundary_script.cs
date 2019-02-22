using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary_script : MonoBehaviour
{
    private List<Rigidbody2D> bodies;

    public int width;
    public int height;

    void Start()
    {
        bodies = new List<Rigidbody2D>();
        foreach (GameObject body in GameObject.FindGameObjectsWithTag("Player"))
        {
            bodies.Add(body.GetComponent<Rigidbody2D>());
            print(body);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Rigidbody2D rb in bodies)
        {
            Vector3 pos = rb.transform.position;

            if (pos.x < (-1) * width / 2 || pos.x > width / 2) rb.transform.position = new Vector3(pos.x * (-1), pos.y, pos.z);
            if (pos.y < (-1) * height / 2 || pos.y > height / 2) rb.transform.position = new Vector3(pos.x, pos.y * (-1), pos.z);
        }
    }
}
