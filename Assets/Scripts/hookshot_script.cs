using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookshot_script : MonoBehaviour
{
    public KeyCode hookshotKey;
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 100f;
    public LayerMask mask;
    public float step = 0.2f;

    private bool hookshotEnabled;

    GameObject[] entities;
    GameObject player;


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        hookshotEnabled = true;
        entities = FindObjectsOfType<GameObject>();
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hookshotKey) && hookshotEnabled)
        {
            GameObject nearestObject = entities[0];
            float closest = Mathf.Infinity;
            float mass;
            float separation;
            float nearestMass = Mathf.Infinity;
            for (int i = 0; i < entities.Length; i++) {
                mass = entities[i].GetComponent<info>().mass;
                separation = (player.GetComponent<Transform>().position - entities[i].GetComponent<Transform>().position).magnitude;

                if (mass != 0 && entities[i] != player && (separation < closest || nearestMass == 0)) {
                    nearestObject = entities[i];
                    nearestMass = mass;
                    closest = separation;
                    targetPos = nearestObject.GetComponent<Transform>().position;
                    targetPos.z = 0;
                }
            }
            Debug.Log(nearestObject);
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            { 
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.collider.transform.position);
            }

        }

        if (Input.GetKey(hookshotKey))
        {
            line.SetPosition(0, transform.position);
        }

        if (Input.GetKeyUp(hookshotKey))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }

    public void setHookShotEnabled(bool w) { hookshotEnabled = w; }

    public bool getHookShotEnabled() { return hookshotEnabled; }
}
